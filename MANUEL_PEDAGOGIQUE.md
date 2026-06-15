# 📘 Manuel Pédagogique : Projet Airport Management

Bienvenue dans ce manuel pédagogique professionnel dédié au projet **Airport Management**. Ce document a été conçu pour guider un développeur ou un étudiant à travers les étapes de conception, de développement et d'architecture d'une application d'entreprise en **.NET 10** et **Entity Framework Core**.

Ce projet respecte les principes de la **Clean Architecture** et utilise des paradigmes avancés de la Programmation Orientée Objet (POO) ainsi que les spécificités modernes du C#.

---

## Table des Matières
1. [Architecture de la Solution](#1-architecture-de-la-solution)
2. [Modélisation du Domaine (Core)](#2-modélisation-du-domaine-core)
3. [Polymorphisme et Héritage](#3-polymorphisme-et-héritage)
4. [Traitement des Données avec LINQ](#4-traitement-des-données-avec-linq)
5. [Infrastructure et Entity Framework Core](#5-infrastructure-et-entity-framework-core)
6. [Conclusion et Bonnes Pratiques](#6-conclusion-et-bonnes-pratiques)

---

## 1. Architecture de la Solution

Afin de garantir un code maintenable et évolutif, le projet est découpé en trois couches distinctes. C'est ce qu'on appelle la **Clean Architecture** (ou architecture en oignon).

* **`Am.ApplicationCore`** : C'est le cœur du système. Il contient la logique métier pure (les Entités, les Services, les Interfaces). **Règle d'or :** Cette couche ne doit avoir aucune dépendance externe (pas de base de données, pas de framework web).
* **`AM.Infra`** : C'est la couche d'accès aux données. Elle référence `Am.ApplicationCore` et contient la configuration d'Entity Framework Core (`DbContext`, Migrations, Configurations Fluent API).
* **`Am.Ui.Console`** : C'est la couche de présentation (point d'entrée de l'application). Elle orchestre l'exécution et référence les deux couches précédentes.

### Pourquoi cette séparation ?
Si l'on décide demain de remplacer la base de données SQL Server par du MongoDB, ou de remplacer la Console par une API REST, la couche `Am.ApplicationCore` ne subira **aucune modification**.

---

## 2. Modélisation du Domaine (Core)

Dans le dossier `Domain` de `Am.ApplicationCore`, nous traduisons nos règles métier en classes C#.

### Les Entités Principales
* `Flight` (Le vol)
* `Plane` (L'avion)
* `Passenger` (Le passager, classe mère)
* `Ticket` (Table porteuse de données pour lier le passager et le vol)

### Exemple : La classe Plane
```csharp
public class Plane
{
    public Plane()
    {
        // ⚠️ Règle d'or : Toujours initialiser les collections dans le constructeur
        // Cela permet d'éviter les fameuses erreurs NullReferenceException.
        Flights = new List<Flight>();
    }

    public int PlaneId { get; set; }

    // Utilisation des Data Annotations pour valider la donnée avant même la base de données
    [Range(1, int.MaxValue, ErrorMessage = "La capacité doit être un entier positif")]
    public int Capacity { get; set; }
    
    public DateTime ManufactureDate { get; set; }
    public PlaneType PlaneType { get; set; }

    // Le mot clé 'virtual' est primordial. Il permet à Entity Framework 
    // d'activer le "Lazy Loading" (Chargement à la demande des vols liés à cet avion).
    public virtual ICollection<Flight> Flights { get; set; }
}
```

---

## 3. Polymorphisme et Héritage

Le projet met en pratique deux concepts majeurs de la POO : le **polymorphisme par signature** (surcharge) et le **polymorphisme par héritage** (redéfinition).

### Héritage
La classe `Passenger` est la classe mère. `Staff` et `Traveller` en héritent :
```csharp
public class Staff : Passenger 
{
    public double Salary { get; set; }
    // ...
}
```

### Polymorphisme par Héritage (`virtual` / `override`)
Dans la classe mère `Passenger`, on définit le comportement par défaut :
```csharp
public virtual void PassengerType()
{
    Console.WriteLine("I am a passenger");
}
```
Dans la classe `Staff`, on le modifie en réutilisant le code parent (`base`) :
```csharp
public override void PassengerType()
{
    base.PassengerType(); // Affiche "I am a passenger"
    Console.WriteLine("I am a staff member");
}
```

---

## 4. Traitement des Données avec LINQ

LINQ (*Language Integrated Query*) permet d'interroger des collections en C# avec une syntaxe similaire à SQL, tout en restant fortement typée.

Dans le fichier `FlightMethods.cs`, nous utilisons LINQ massivement.

```csharp
// Exemple : Récupérer les 3 voyageurs les plus âgés d'un vol
public IList<Passenger> SeniorTravellers(Flight flight)
{
    return flight.Tickets
        .Select(t => t.Passenger) // On extrait les passagers des tickets
        .OfType<Traveller>()      // On filtre uniquement ceux de type "Traveller"
        .OrderBy(t => t.BirthDate) // Tri croissant par date de naissance (les plus vieux d'abord)
        .Take(3)                   // On en garde 3
        .Cast<Passenger>()
        .ToList();
}
```
**Avantage :** Le code est concis, déclaratif (on dit *ce qu'on veut* et non *comment le faire* avec des boucles `foreach`), et hautement performant.

---

## 5. Infrastructure et Entity Framework Core

La couche `AM.Infra` traduit nos classes C# en tables SQL Server grâce au `AMContext`.

### A. L'Héritage côté Base de Données (TPH)
Comment stocker `Passenger`, `Traveller` et `Staff` ? Nous avons opté pour le **TPH (Table Per Hierarchy)**. 
Toutes ces classes sont stockées dans une seule table `Passengers`. Une colonne spéciale (le *Discriminator*) indique le type d'objet.

```csharp
protected override void OnModelCreating(ModelBuilder modelBuilder)
{
    // Configuration Fluent API du TPH
    modelBuilder.Entity<Passenger>()
        .HasDiscriminator<int>("IsTraveller")
        .HasValue<Passenger>(0)
        .HasValue<Traveller>(1)
        .HasValue<Staff>(2);
}
```

### B. Table Porteuse de Données (La classe Ticket)
Souvent, une relation de type "Plusieurs-à-Plusieurs" (Many-to-Many) cache une table porteuse. Ici, un `Flight` et un `Passenger` sont liés par un `Ticket` (qui possède un Prix, un Siège, etc.).

Dans `TicketConfig.cs`, on définit sa clé primaire composite (composée de deux clés étrangères) :
```csharp
public void Configure(EntityTypeBuilder<Ticket> builder)
{
    builder.HasKey(t => new { t.PassengerFK, t.FlightFK });
    
    builder.HasOne(t => t.Passenger).WithMany(p => p.Tickets).HasForeignKey(t => t.PassengerFK);
    builder.HasOne(t => t.Flight).WithMany(f => f.Tickets).HasForeignKey(t => t.FlightFK);
}
```

### C. Le Lazy Loading
Pour éviter de ramener toute la base de données en mémoire, on active le Lazy Loading via les Proxies :
```csharp
protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
{
    // Lazy Loading activé + Connexion SQL Server
    optionsBuilder.UseLazyLoadingProxies().UseSqlServer(@"Data Source=(localdb)...");
}
```
**Condition requise :** Les propriétés de navigation (ex: `ICollection<Ticket>`) doivent obligatoirement comporter le mot clé `virtual`.

---

## 6. Conclusion et Bonnes Pratiques

Ce projet démontre qu'un système d'entreprise ne s'écrit pas "d'un seul bloc".
1. **Pensez toujours métier en premier** : Codez votre `ApplicationCore` sans vous soucier de la base de données.
2. **Utilisez Fluent API pour les règles complexes** : Les Data Annotations (`[Key]`) sont pratiques, mais le Fluent API (`OnModelCreating`) permet de séparer complètement la configuration des entités.
3. **Migrez prudemment** : Chaque modification du modèle doit se faire via une migration EF (`dotnet ef migrations add ...`). C'est le Git de votre base de données.

*Fin du manuel pédagogique. Bonne pratique et bon code !*
