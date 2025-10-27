using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using MonProjetTest;

#region Quatrième exo
// Programme qui permet d'ajouter la liste des Personne à un Objet Classe qui comporte une liste d'élève,
// un nom, une école, un niveau

// On récupère le csv
String path = @"C:\Users\Manon ROUSSELIERE\Documents\Sup de Vinci\B2\C#\MonProjetTest\donnees_perso.csv";

Classe classeB2 = new Classe("B2 Informatique", "Bachelor 2", "Sup de Vinci");

var lignes = File.ReadAllLines(path); 

#region Boucle pour ajouter toutes les personnes du CSV dans la classe
for (int i = 1; i < lignes.Length; i++)
{
    String ligne = lignes[i];
    String[] colonnes = ligne.Split(','); // pour simplifier la suite on fait le split ici
    
    Person person = new Person();
    {
     person.LastName = colonnes[1];
     person.FirstName = colonnes[2];
     person.BirthDate = ConvertToDateTime(colonnes[3]);
     person.Taille = int.Parse(colonnes[5]); 
    };

    // on sépare la date pour la mettre au format rue, code postal, ville
    List<String> details = ligne.Split(',')[4].Split(';').ToList(); 
    person.AddressDetails = new Detail(details[0], int.Parse(details[1]), details[2]);

    classeB2.List_Eleve.Add(person); // on mets la personne dans la classe
}
#endregion

// calcul de la moyenne de la taille de la classe
double moyenne = classeB2.List_Eleve.Average(person => person.Taille);
double moyenneMetre = Math.Floor(moyenne) / 100;

// les élèves de nantes & plus grands que la moyenne
var grandNantes = classeB2.List_Eleve.Where(person => person.AddressDetails.City == "Nantes" && person.Taille > moyenne);

// on mets dans l'ordre décroissant (du plus grand au plus petit)
    grandNantes = grandNantes.OrderByDescending(person => person.Taille);

// on en fait une liste pour pouvoir l'afficher élément par élément
    List<Person> grandNantesList = grandNantes.ToList();

#region affichage de la moyenne puis du classement des tailles par ordre decroissant 
Console.WriteLine($"Moyenne de la classe : {moyenneMetre} m");
for (int i = 0; i < grandNantesList.Count; i++) // boucle qui sélectionne tous les grands nantais dans l'ordre decroissant
{
    var eleve = grandNantesList[i];
    Console.WriteLine($"{i + 1} - {eleve.FirstName} - {eleve.Taille / 100.0} m"); 
}
#endregion


#region Convertion de la date (pas utile pour cet exercice précis)
DateTime ConvertToDateTime(String date)
{
    if (DateTime.TryParse(date, out DateTime birthdate))
    {
        return  birthdate;
    }
    else
    {
        Console.WriteLine($"La date '{date}' est mal renseignée");
        return DateTime.Now;
    }
}
#endregion
#endregion