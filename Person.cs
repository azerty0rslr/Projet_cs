using MonProjetTest;

public class Person
{
    private String lastName ;
    private String firstName;
    private DateTime birthDate;
    private Detail addressDetails;
    private int taille;
    
    public Detail AddressDetails
    {
        get => addressDetails;
        set => addressDetails = value ?? throw new ArgumentNullException(nameof(value));
    }
    public DateTime BirthDate
    {
        get => birthDate;
        set => birthDate = value;
    }
    public String FirstName
    {
        get => firstName;
        set => firstName = value ?? throw new ArgumentNullException(nameof(value));
    }
    public String LastName
    {
        get => lastName;
        set => lastName = value ?? throw new ArgumentNullException(nameof(value));
    }
    
    public int Taille
    {
        get => taille;
        set => taille = value;
    }
    
    public int getYearsOld()
    {
        DateTime today = DateTime.Today;

        int years = today.Year - birthDate.Year;

        if (today.Month < birthDate.Month || today.Month == birthDate.Month && today.Day < birthDate.Day)
        {
            years--;
        }
        
        return years;
    }
}