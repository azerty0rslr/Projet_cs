namespace MonProjetTest;

public class Classe
{
    private List<Person> list_eleve ;
    private String nom;
    private String ecole;
    private String niveau;

    public List<Person> List_Eleve
    {
        get => list_eleve;
        set => list_eleve = value ?? throw new ArgumentNullException(nameof(value));
    }

    public string Nom
    {
        get => nom;
        set => nom = value ?? throw new ArgumentNullException(nameof(value));
    }

    public string Ecole
    {
        get => ecole;
        set => ecole = value ?? throw new ArgumentNullException(nameof(value));
    }

    public string Niveau
    {
        get => niveau;
        set => niveau = value ?? throw new ArgumentNullException(nameof(value));
    }

    public Classe(string nom, string ecole, string niveau)
    {
        this.nom = nom;
        this.ecole = ecole;
        this.niveau = niveau;
        list_eleve = new List<Person>();
    }
}