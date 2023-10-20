namespace Activ.Pointis.Android.PersonnelUI;

public partial class AppShell : Shell
{
    private long id ;
    private string telephone;

    public AppShell()
	{
        InitializeComponent();

        /*
         // Chemin d'accès au fichier de connexion
        string filePath = "\\DétailConnexion\\connexion.txt";

        // Vérifie si le fichier de connexion existe
        if (File.Exists(filePath))
        {
            // Si le fichier de connexion existe, lit le contenu du fichier
            string[] lines = File.ReadAllLines(filePath);

            // Récupère les informations de connexion (login et mot de passe)
            id = long.Parse(lines[0]);
            telephone = lines[1];

            App.Current.MainPage = new NavigationPage(new ComptePage());
            //Shell.Current.GoToAsync("//Compte");
        }
        else
        {
            // Si le fichier de connexion n'existe pas, redirige l'utilisateur vers la page de connexion
            //Shell.Current.GoToAsync("//Login");
            InitializeComponent();
        }
        */
    }
}
