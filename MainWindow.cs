using System;
using System.IO;
using System.Text;
using Gtk;
using System.Collections.Generic;
using Cairo;
using pert_implementation;

public partial class MainWindow : Gtk.Window
{
    public const int width = 50; // largeur de sommet (etape)
    public const int height = 50; // longueur de sommet (etape)
    public static Color black = new Color(0, 0, 0); // declaration du couleur Noir utilisée.
    public static pert_implementation.pert_implementation pert; // declaration d'un objet pert_implementation (liste des taches+etape final contient la durée total)
    public static List<Task> criticalPath = new List<Task>(); // declaration d'une liste des taches qui va representer le chemin critique.
    public static List<Task> loadedTasks = new List<Task>(); // la liste où on va mettre les taches chargées à partir du fichier.

    public MainWindow() : base(Gtk.WindowType.Toplevel)
    {
        Build(); // construction de l'interface.
        button7.Sensitive = false; // rendre le bouton Dessiner le graphe desactivé.
        button8.Sensitive = false; // rendre le bouton Effacer le graphe desactivé.
    }

    // La méthode resposable de dessin graphique de graphe (etapes+taches)
    void OnExpose(object sender, ExposeEventArgs args)
    {
        int number = 1; // numérotation des étapes.
        DrawingArea area = (DrawingArea)sender; // récupération de l'objet DrawingArea
        Cairo.Context context = Gdk.CairoHelper.Create(area.GdkWindow); // Création d'un context a partir de la bibliothéque Mono Cairo
        int WindowHeight = area.Allocation.Height; // la hauteur de l'espace du dessin .
        int windowWidth = area.Allocation.Width; // la largeur de l'espace du dessin .
        PointD projectCloture = new PointD(windowWidth - 50, WindowHeight / 2); // le point ou va mettre la derniere étape.
        PointD firstStep = new PointD(50, WindowHeight / 2);  // le point ou va mettre la 1ere étape.
        // ici on commence le dessin du graphe.
        foreach(var task in pert.projectTasks)
        {
            
            // on commence par les taches de rang 1
            if (task.taskLevel == 1)
            {
                // si la tache courante posséde un seule successeur
                if (task.successors.Count == 1)
                {
                    context.SetSourceColor(task.color);
                    task.painted = true; // pour dire qu'on a atteint la tache courante et on la dessine.
                    context.MoveTo(firstStep);  // on deplace le context (painter) vers la 1ere étape
                    // On a crée un point qui est la fin de la tache courante pour relier la 1ere etape avec cette fin par un arc qui est la tache.
                    PointD p = new PointD(task.finishStep.coordX, task.finishStep.coordY);
                    // Deplacer le context vert le point 'p' mais cette fois avec LineTo (c-à-d dessiner une ligne)
                    context.LineTo(p);
                    // Stroke() pour remplir la ligne dessinée.
                    context.Stroke();
                    // on deplace le context (painter) vers le point 'p'
                    context.MoveTo(p);
                    // maintenant, on va dessiner l'étape suivante qui est la fin du premier tache.
                    context.Arc(p.X, p.Y, (width < height ? width : height) / 2 - 10, 0, 2 * Math.PI);
                    // Fill() pour remplir le circle.

                    context.Fill();
                    // ici on va selectionner le police utilisé et la taille du text pour afficher : N°etape,marge,dd+tot,dd+tard
                    context.SelectFontFace("Tahoma", FontSlant.Normal, FontWeight.Normal);
                    context.SetFontSize(11);
                    PointD mid = pert.MidPoint(firstStep, p);
                    context.MoveTo(new PointD(mid.X, mid.Y));
                    context.ShowText(task.taskName+","+task.taskDuration);
                    context.MoveTo(new PointD(p.X - 5, p.Y - 20));
                    context.ShowText(task.successors[0].startStep.earliestStart.ToString());
                    context.MoveTo(new PointD(p.X - 5, p.Y + 30));
                    context.ShowText(task.successors[0].startStep.latestStart.ToString());
                    //
                    context.MoveTo(new PointD(p.X - 30, p.Y));
                    context.ShowText(number.ToString());
                    number++; // on incremente number pour l'étape suivante.
                    context.MoveTo(new PointD(p.X + 20, p.Y));
                    context.ShowText(task.successors[0].startStep.margin.ToString());
                }
                else
                {
                    context.SetSourceColor(task.color);
                    // Comme la tache a plusieurs successeurs donc lors de l'affichage des dd+tot et +tard , on affiche seulement les + petits.
                    List<int> datesEar = new List<int>();
                    List<int> datesLat = new List<int>();
                    // pour chaque successeur on sauvegarde la dd+tot dans une liste , et la meme chose pour les dd+tard mais dans une autre liste
                    foreach (var successor in task.successors)
                    {
                        datesEar.Add(successor.startStep.earliestStart);
                        datesLat.Add(successor.startStep.latestStart);
                    }
                    // Si la tache courante à pluisuers successeurs:
                    //On va suivre les memes etapes dans le teste précédent.
                    task.painted = true;
                    context.MoveTo(firstStep);
                    PointD p = new PointD(task.finishStep.coordX, task.finishStep.coordY);
                    context.LineTo(p);
                    if((pert.findMinimum(datesLat) - pert.findMinimum(datesEar))==0)
                    {
                        context.SetSourceColor(new Color(1,0,0));
                    }
                    context.Stroke();
                    context.MoveTo(p);
                    context.Arc(p.X, p.Y, (width < height ? width : height) / 2 - 10, 0, 2 * Math.PI);

                    context.Fill();
                    context.SelectFontFace("Tahoma", FontSlant.Normal, FontWeight.Normal);
                    context.SetFontSize(11);
                    PointD mid = pert.MidPoint(firstStep, p);
                    context.MoveTo(new PointD(mid.X, mid.Y));
                    context.ShowText(task.taskName + "," + task.taskDuration);
                    // Comme la tache a plusieurs successeurs donc lors de l'affichage des dd+tot et +tard , on affiche seulement les + petits.
                    context.MoveTo(new PointD(p.X - 5, p.Y - 20));
                    context.ShowText(pert.findMinimum(datesEar).ToString()); // on receupere et affiche la plus petit dd+tot.
                    context.MoveTo(new PointD(p.X - 5, p.Y + 30));
                    context.ShowText(pert.findMinimum(datesLat).ToString());  // on receupere et affiche la plus petit dd+tard.
                    //
                    context.MoveTo(new PointD(p.X - 30, p.Y));
                    context.ShowText(number.ToString());
                    number++;
                    context.MoveTo(new PointD(p.X + 20, p.Y));
                    // la marge est la différence entre les 2 dates.
                    context.ShowText((pert.findMinimum(datesLat) - pert.findMinimum(datesEar)).ToString());
                    context.SetSourceColor(black);
                }
            }
            else // maintenant si la tache n'est pas de rang 1.
            {
                if (task.successors.Count == 1) // comme le teste précédent , si la tache à un seule successeur.
                {
                    
                    PointD p;
                    PointD p1;
                    if(pert.isPaintedAllAntecedents(task.successors[0].antecedent)) // si tous les antecedants du successeur ont été dessinés.on dessine seulement une ligne sans redissiner l'étape.
                    {
                        task.painted = true; // on marque que le tache courante comme : dessinée.
                        // le point 'p' represnte le debut de la tache courante .
                        p = new PointD(task.startStep.coordX, task.startStep.coordY);
                        // le point 'p1' represnte le fin de la tache courante .
                        p1 = new PointD(task.finishStep.coordX, task.finishStep.coordY);
                        // deplacement de context vers p.
                        context.MoveTo(p);
                        // on dessine un ligne vers p1
                        context.LineTo(p1);
                        // remplissage du ligne dessinée.
                        context.Stroke();
                        context.SelectFontFace("Tahoma", FontSlant.Normal, FontWeight.Normal);
                        context.SetFontSize(11);
                        PointD mid = pert.MidPoint(p, p1);
                        // au milieu de la ligne , en affiche le nom de la tache et sa durée.
                        context.MoveTo(new PointD(mid.X, mid.Y));
                        context.ShowText(task.taskName + "," + task.taskDuration);
                    }
                    else{


                        // S'il y a des antecedant de successeur qui ne sont pas encore dessinées.
                        // on répete le meme travail , mais on en dessine cette fois l'étape.
                        task.painted = true;
                        p = new PointD(task.startStep.coordX, task.startStep.coordY);
                        p1 = new PointD(task.finishStep.coordX, task.finishStep.coordY);
                        context.MoveTo(p);
                        context.LineTo(p1);
                        context.SetSourceColor(task.color);
                        context.Stroke();
                        if (!pert.ifExistTaskMarginZero(task))
                        {
                            context.MoveTo(p1);
                            context.Arc(p1.X, p1.Y, (width < height ? width : height) / 2 - 10, 0, 2 * Math.PI);
                            context.SetSourceColor(task.color);
                            context.Fill();
                            context.SelectFontFace("Tahoma", FontSlant.Normal, FontWeight.Normal);
                            context.SetFontSize(11);
                            PointD mid = pert.MidPoint(p, p1);
                            context.MoveTo(new PointD(mid.X, mid.Y));
                            context.ShowText(task.taskName + "," + task.taskDuration);
                            //
                            context.MoveTo(new PointD(p1.X - 5, p1.Y - 20));
                            context.ShowText(task.successors[0].startStep.earliestStart.ToString());
                            context.MoveTo(new PointD(p1.X - 5, p1.Y + 30));
                            context.ShowText(task.successors[0].startStep.latestStart.ToString());
                            //
                            context.MoveTo(new PointD(p1.X - 30, p1.Y));
                            context.ShowText(number.ToString());
                            number++;
                            context.MoveTo(new PointD(p1.X + 20, p1.Y));
                            context.ShowText(task.successors[0].startStep.margin.ToString());
                            context.SetSourceColor(black);
                        }
                    }
                }else{ // si la tache courante a un nombre de successeur !=1
                        // il peut etre +1 ou bien 0
                    if(task.successors.Count>1){ // si le nombre du successeurs et superieur à 1.
                        context.SetSourceColor(task.color);

                        PointD p;
                        PointD p1;
                        // si tous les antecedant d'un des successuers ont été dessinées.
                        // on dessine seulement la ligne (la tache).
                        if (pert.isPaintedAllAntecedents(task.successors[0].antecedent))
                        {
                            
                            // le meme travail pour les tests précédents.
                            // deplacement vers p et ligne vers p1.

                            task.painted = true;
                            p = new PointD(task.startStep.coordX, task.startStep.coordY);
                            context.MoveTo(p);
                            p1 = new PointD(task.finishStep.coordX, task.finishStep.coordY);
                            context.LineTo(p1);
                            context.Stroke();
                            context.SelectFontFace("Tahoma", FontSlant.Normal, FontWeight.Normal);
                            context.SetFontSize(11);
                            PointD mid = pert.MidPoint(p, p1);
                            context.MoveTo(new PointD(mid.X, mid.Y));
                            context.ShowText(task.taskName + "," + task.taskDuration);
                        }else{ // sinon, en dessine la ligne + l'étape .
                            // le travail est similaire .
                            task.painted = true;
                            p = new PointD(task.startStep.coordX, task.startStep.coordY);
                            context.MoveTo(p);
                            p1 = new PointD(task.finishStep.coordX, task.finishStep.coordY);
                            context.LineTo(p1);
                            context.Stroke();
                            context.MoveTo(p1);
                            context.Arc(p1.X, p1.Y, (width < height ? width : height) / 2 - 10, 0, 2 * Math.PI);
                            context.Fill();
                            context.SelectFontFace("Tahoma", FontSlant.Normal, FontWeight.Normal);
                            context.SetFontSize(11);
                            PointD mid = pert.MidPoint(p, p1);
                            context.MoveTo(new PointD(mid.X, mid.Y));
                            context.ShowText(task.taskName + "," + task.taskDuration);
                            List<int> datesEar = new List<int>();
                            List<int> datesLat = new List<int>();
                            // ici le meme travail du choix  de minimum.
                            foreach (var successor in task.successors)
                            {
                                datesEar.Add(successor.startStep.earliestStart);
                                datesLat.Add(successor.startStep.latestStart);
                            }
                            context.MoveTo(new PointD(p1.X - 5, p1.Y - 20));
                            context.ShowText(pert.findMinimum(datesEar).ToString());
                            context.MoveTo(new PointD(p1.X - 5, p1.Y + 30));
                            context.ShowText(pert.findMinimum(datesLat).ToString());
                            //
                            context.MoveTo(new PointD(p1.X - 30, p1.Y));
                            context.ShowText(number.ToString());
                            number++;
                            context.MoveTo(new PointD(p1.X + 20, p1.Y));
                            context.ShowText((pert.findMinimum(datesLat) - pert.findMinimum(datesEar)).ToString());
                        }
                    }else{ // task.successors.Count==0 , les taches qui n'ont pas de successeurs.
                        // le même travail 
                        context.SetSourceColor(task.color);

                        task.painted = true;
                        PointD p = new PointD(task.startStep.coordX, task.startStep.coordY);
                        PointD p1 = new PointD(task.finishStep.coordX, task.finishStep.coordY);
                        context.MoveTo(p);
                        context.LineTo(p1);
                        context.Stroke();
                        context.SelectFontFace("Tahoma", FontSlant.Normal, FontWeight.Normal);
                        context.SetFontSize(11);
                        PointD mid = pert.MidPoint(p, p1);
                        context.MoveTo(new PointD(mid.X,mid.Y));
                        context.ShowText(task.taskName + "," + task.taskDuration);
                    }
                }
            }
        }
        // on dessine ici la premiere étape.
        // les memes instructions se repetent.

        context.SetSourceColor(new Color(1, 0, 0));
        context.MoveTo(firstStep);
        context.Arc(firstStep.X, firstStep.Y, (width < height ? width : height) / 2 - 10, 0, 2 * Math.PI);
        context.Fill();
        context.SelectFontFace("Tahoma", FontSlant.Normal, FontWeight.Normal);
        context.SetFontSize(11);
        context.MoveTo(new PointD(47, (WindowHeight / 2) - 20));
        context.ShowText("0");
        context.MoveTo(new PointD(47, (WindowHeight / 2) + 27));
        context.ShowText("0");
        context.MoveTo(new PointD(25, (WindowHeight / 2) + 4));
        context.ShowText("0");
        context.MoveTo(new PointD(68, (WindowHeight / 2) + 4));
        context.ShowText("0");
        // on dessine ici la premiere étape.
        // les memes instructions se repetent.
        PointD lastStep = new PointD(windowWidth - 50, WindowHeight / 2);
        context.MoveTo(lastStep);
        context.Arc(lastStep.X, lastStep.Y, (width < height ? width : height) / 2 - 10, 0, 2 * Math.PI);
        context.Fill();
        context.SelectFontFace("Tahoma", FontSlant.Normal, FontWeight.Normal);
        context.SetFontSize(11);
        context.MoveTo(new PointD(windowWidth - 55, (WindowHeight / 2) - 20));
        context.ShowText(pert.lastStep.earliestStart.ToString());
        context.MoveTo(new PointD(windowWidth - 55, (WindowHeight / 2) + 27));
        context.ShowText(pert.lastStep.latestStart.ToString());
        context.MoveTo(new PointD(windowWidth - 75, (WindowHeight / 2) + 4));
        context.ShowText(number.ToString());
        context.MoveTo(new PointD(windowWidth - 30, (WindowHeight / 2) + 4));
        context.ShowText(pert.lastStep.margin.ToString());
        context.GetTarget().Dispose();
        context.Dispose();
        // fermeture du context utilisé pour le dessin pour eviter le crash de l'application
        // context.Dispose(); est suffisante , mais de préférence d'utiliser contextDep.GetTarget().Dispose(); aussi.
    }

    protected void OnDeleteEvent(object sender, DeleteEventArgs a)
    {
        Application.Quit();
        a.RetVal = true;
    }

    public void start(object sender, EventArgs e)
    {
        // Le bouton occupé par cette méthode est desactivé jusqu'on choisis un fichier CSV
        // Aprés le choix d'un fichier CSV contient les taches avec ses informations et clique sur le bouton dessiner le graphe.

        // on affiche la durée total du projet.
        label82.LabelProp = Mono.Unix.Catalog.GetString("La durée minimal de ce projet est : ");
        label84.LabelProp = Mono.Unix.Catalog.GetString("<b>" + pert.lastStep.earliestStart.ToString() + " UT</b>");
        label86.LabelProp = Mono.Unix.Catalog.GetString("Le chemin critique est : ");
        String critical_path = "";
        foreach (var task in criticalPath)
        {
            critical_path += " " + task.taskName;
        }
        // on affiche le chemin critique .
        label88.LabelProp = Mono.Unix.Catalog.GetString("<b>" + critical_path + "</b>");
        // traitement
        drawingarea.ExposeEvent += this.OnExpose; // expose event nécéssite un changement dans l'interface, exemple : agrandir 
        this.QueueDraw(); // pour cela on utilise la méthode QueueDraw() pour redessiner l'ensemble de l'interface sans faire des changements.
        button7.Sensitive = false; // rendre le bouton 'Dessiner le graphe' desactivé.
        button8.Sensitive = true; // rendre le bouton 'Effacer le graphe' desactivé.
        button6.Sensitive = false; // rendre le bouton 'Parcourir ...' desactivé.
    }

    // Cette méthode declanche lorsqu'on clique sur le bouton de choi d'un fichier 'Parcourir ...'
    protected void OpenControlFile(object sender, EventArgs e)
    {
        // Affichage d'un 'file chooser dialog' , une fenetre qui nous permet de choisir un fichier
        Gtk.FileChooserDialog filechooser =
                new Gtk.FileChooserDialog("Choisir un fichier CSV", this, FileChooserAction.Open,
                    "Cancel", ResponseType.Cancel,
                    "Open", ResponseType.Accept);

        // Si le un fichier est choisis et la demande d'ouveture a été lancée
        if (filechooser.Run() == (int)ResponseType.Accept)
        {
            // On recupére le fichier a partir de l'objet filechooser.
            // et on l'ouvre sous forme de flux.
            FileStream file = File.OpenRead(filechooser.Filename);
            // on affiche le chemin du fichier choisis.
            label1.LabelProp = Mono.Unix.Catalog.GetString("Fichier choisis : " + filechooser.Filename);

            // Dans cette partie on va lire ligne par ligne le fichier CSV choisis
            using(var streamReader = new StreamReader(file,Encoding.UTF8))
            {
                // on lit la premiere ligne qui contient les titres et feront rien!
                streamReader.ReadLine();
                String line = ""; // variable qui va contenir la ligne lu.
                Dictionary<String,Task> tasks = new Dictionary<String,Task>(); // dictionnaire temporaire pour charger les taches à partir du fichier. "nom_tache" => Task
                Dictionary<String,List<String>> antecedants = new Dictionary<String,List<String>>(); // dictionnaire temporaire pour charger les antécédants à partir du fichier. "nom_tache" => List des taches anteced.
                Dictionary<String, List<String>> successors = new Dictionary<String, List<String>>(); // dictionnaire temporaire pour charger les successeurs à partir du fichier. "nom_tache" => List des taches successeurs.
                while((line=streamReader.ReadLine())!=null) // tantqu'il existe une nouvelle ligne, on la mettre dans line.
                {

                    // en utilise la méthode Split avec un point virgule 
                    // pour chaque point virgule elle met le bloc précédent dans le tableau blocs
                    String[] blocs = line.Split(';');
                    List<String> taskBloc = new List<string>();
                    taskBloc.Add(blocs[0]);
                    // taskBloc contient le nom de la tache et sa durée.
                    List<String> antecedBloc = new List<string>();
                    antecedBloc.Add(blocs[1]);
                    // antecedBloc contient les taches antecedantes.
                    List<String> succesBloc = new List<string>();
                    succesBloc.Add(blocs[2]);
                    // succesBloc contient les taches successeurs.
                    // maintenant on utlise Split avec une virgule pour separer les informations complexes dans chaque bloc.
                    String[] NameAndDuration = taskBloc[0].Split(',');
                    // NameAndDuration : ["nom_tache","durée"]
                    String[] antecedant = antecedBloc[0].Split(',');
                    // antecedant : ["tache anteced1","tache anteced2",...]
                    String[] successor = succesBloc[0].Split(',');
                    // successor : ["tache success1","tache success2",...]
                    tasks.Add(NameAndDuration[0],new Task(int.Parse(NameAndDuration[1]),NameAndDuration[0]));
                    // on ajoute la tache au dictionnaire temporaire .

                    // si la tache de la ligne courante posséde des antécédants .
                    if(antecedant[1]!="rien")
                    {
                        List<String> tmp = new List<string>();
                        for (int i = 1; i < antecedant.Length;i++)
                        {
                            tmp.Add(antecedant[i]);
                        }
                        // on ajoute au dictionnaire des antecedants : "nom_tache" => liste des antécédants.
                        antecedants.Add(NameAndDuration[0],tmp);
                    }else{
                        // sinon on ajoute une liste vide dans le dictionnaire pour la tache courante : "nom_tache" => liste vide.
                        antecedants.Add(NameAndDuration[0],new List<string>(){});
                    }
                    // si la tache de la ligne courante posséde des successeurs .
                    if (successor[1] != "rien")
                    {
                        List<String> tmp = new List<string>();
                        for (int i = 1; i < successor.Length; i++)
                        {
                            tmp.Add(successor[i]);
                        }
                        // on ajoute au dictionnaire des antecedants : "nom_tache" => liste des antécédants.
                        successors.Add(NameAndDuration[0],tmp);
                    }
                    else{
                        // sinon on ajoute une liste vide dans le dictionnaire pour la tache courante : "nom_tache" => liste vide.
                        successors.Add(NameAndDuration[0], new List<string>() {});
                    }
                }


                // apres le parcours total du fichier et l'enregistrement de toutes les taches 
                foreach(var task in tasks)
                {
                    List<Task> anteced = new List<Task>();
                    // pour la tache courante on recupére la liste des antecedants.
                    List<String> list = antecedants[task.Key];
                    foreach(var item in list)
                    {
                        anteced.Add(tasks[item]);
                    }
                    // on met a jour la liste des antecedants de la tache courante.
                    task.Value.setAntecedants(anteced);
                }
                foreach (var task in tasks)
                {
                    List<Task> successor = new List<Task>();
                    // pour la tache courante on recupére la liste des antecedants.
                    List<String> list = successors[task.Key];
                    foreach (var item in list)
                    {
                        successor.Add(tasks[item]);
                    }
                    // on met a jour la liste des antecedants de la tache courante.
                    task.Value.setSuccessors(successor);
                }
                // on initialise les étapes de chaque tache.
                foreach(var task in tasks)
                {
                    task.Value.setSteps(new step(0),new step(0));
                }
                // et en fin , on ajoute les tache qui se trouve dans le dictionnaire dans une List<Task> 
                foreach(var task in tasks)
                {
                    loadedTasks.Add(task.Value);
                }
                streamReader.Close(); // fermeture du lecteur de flux.
                pert = new pert_implementation.pert_implementation(); // creation d'un objet pert_implementation.
                pert.projectTasks = loadedTasks; // on donne la liste des taches comme loadedTasks.
                pert.findLevels(); // on trouve les rang des taches.
                pert.setEarliestStart(); // on calcule les dd+tot.
                pert.setLatestStart(); // on calcule les dd+tard.
                pert.findMargins(); // on calcule des marges totales.
                pert.findCoordByLevel(500); // on calcule les coordonnéees X et Y de chaque étape.
                pert.switchSteps(); // mettre la fin de la tache comme debut des successeurs de cette tache. 
                pert.switchStepsAnteced(); // mettre mettre la fin des antecedants comme le début de la tache courante .
                criticalPath = pert.findCriticalPath(); // on trouve le chemin critique.
                pert.setStartEnd();
                button7.Sensitive = true; // on rendre le bouton 'Dessiner le graphe' active.


                // Pour affichage dans la console.
                foreach (var task in pert.projectTasks)
                {
                    Console.WriteLine("Task : " + task.taskName + " | Plutpôt : " + task.startStep.earliestStart + " | Plutard : " + task.startStep.latestStart + " | Rang : " + task.taskLevel);
                }
                Console.WriteLine("________________________________________________");
                Console.WriteLine("Le chemin critique est :");
                foreach (var p in criticalPath)
                {
                    Console.Write(p.taskName + " ");
                }
                Console.WriteLine();
                Console.WriteLine("Durée total du projet : " + pert.lastStep.earliestStart);

            }
        }
        filechooser.Destroy(); // destruction du dialogue de choi du fichier.
    }

    // méthode pour effacer le graphe actuel.
    protected void eraseGraphe(object sender, EventArgs e)
    {
        /* elimination de l'ecouteur d'evenements OnExpose pour drawingarea pour ne pas redessiner le graphe une autre fois 
         * jusqu'on choisis un autre fichier CSV.        
        */
        drawingarea.ExposeEvent -= this.OnExpose;
        // effacement du graphe.
        drawingarea.GdkWindow.Clear();
        // initialisation de la liste des taches pour l'objet statique pert.
        pert.projectTasks = new List<Task>();
        // initialisation de la liste qui contient le chemin critique.
        criticalPath = new List<Task>();
        // initialisation de la liste des taches.
        loadedTasks = new List<Task>();
        // vidage des éttiquettes.
        label82.LabelProp = Mono.Unix.Catalog.GetString("");
        label84.LabelProp = Mono.Unix.Catalog.GetString("");
        label86.LabelProp = Mono.Unix.Catalog.GetString("");
        label88.LabelProp = Mono.Unix.Catalog.GetString("");
        label1.LabelProp = Mono.Unix.Catalog.GetString("");
        // rendre le bouton de choi du fichier active.
        button6.Sensitive = true;
    }
}
