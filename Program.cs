using System;
using Gtk;
using System.Collections.Generic;
using Cairo;

namespace pert_implementation
{

    // definition de la classe Etape.
    public class step
    {
        public int stepNumber { get; set; } // numéro d'étape
        public int earliestStart { get; set; } // date de debut au plutot de la tache suivante.
        public int latestStart { get; set; } // date de debut au plutard de la tache suivante.
        public int margin { get; set; } // la marge total.
        public double coordX { get; set; } // coordonnée X sur le graphe.
        public double coordY { get; set; } // coordonnée Y sur le graphe.

        public step(int number) // constructeur de la classe Etape , ce constructeur est utilisé pour toutes les étapes sauf la derniere.
        {
            this.stepNumber = number; // numero de l'étape donné en paramatres
            this.earliestStart = -1; // initialisaton de toutes les propriétés a -1 (avant le début du traitement)
            this.latestStart = -1;
            this.margin = -1;
            this.coordY = -1;
            this.coordX = -1;
        }
        public step(int number, int delay) // un constructeur pour la derniere étape (fin du projet)
        {
            this.stepNumber = number; // numero de l'étape donné en paramatres
            this.earliestStart = delay; // ici on donne la durée total du projet (aprés le traitement et le calcule bien sure !)
            this.latestStart = delay; // ici on donne la durée total du projet (aprés le traitement et le calcule bien sure !)
            this.margin = 0; // la marge = 0 .
            this.coordY = -1; // initialisation du coordonnée X et Y avant le traitement
            this.coordX = -1;
        }
    }

    // definition de la classe Tache.
    public class Task
    {
        public int taskDuration { get; set; } // la durée de la tache.
        public String taskName { get; } // le nom de la tache.
        public int taskLevel { get; set; } // le rang de la tache
        public List<Task> antecedent { get; set; } // la liste des taches antécédantes.
        public List<Task> successors { get; set; } // la liste des taches successeurs.
        public step startStep { get; set; } // chaque tache à 2 extrimités , donc je l'ai appellé etapeDebut et etapeFin.
        public step finishStep { get; set; }
        public bool painted { get; set; } // j'ai utilisé cette variable booléene dans le dessin du graphe.
        public Color color { get; set; }

        public Task(int duration , String name) // constructeur de la classe Tache
        {
            this.taskDuration = duration; // initialisation des propriétés nom,durée
            this.taskName = name;
            this.taskLevel = -1; // la rang initialement n'existe pas
            this.painted = false; // cette tache n'est pas encore dessinée.
            this.color = new Color(0,0,0);
        }

        // Des méthodes setters pour la classe Tache.

        public void setAntecedants(List<Task> antecedants) // pour attaché les tache anteced pour une tache.
        {
            this.antecedent = antecedants;
        }
        public void setSuccessors(List<Task> successors) // pour attaché les tache successeurs pour une tache.
        {
            this.successors = successors;
        }
        public void setSteps(step start, step finish) // pour attaché etapeDebut et etapeFin a une tache.
        {
            this.startStep = start;
            this.finishStep = finish;
        }
    }
    public class pert_implementation
    {

        /* voici la classe qui contient tous le travail.
         * Les attributs de cette classe définis une liste des taches et une fin du projet (cette fin va contient bien sure la durée total)
         * La durée total sera calculé apres le calcule des dates au plutot des taches.
        */

        public List<Task> projectTasks; // listes des taches .
        public step lastStep; // derniere étape (fin du projet)

        public void findLevels() // la méthode qui calcule les rangs des taches.
        {
            int taskNumbers = projectTasks.Count; // le nombre des taches dans ce projet .
            int addedLevels = 0; // le nombre des taches que nous avons déja calculé ses rangs.

            // recherche de taches qui n'ont pas d'antecédants.
            foreach (var task in projectTasks)
            {
                if (task.antecedent.Count == 0)
                {
                    task.taskLevel = 1; // attaché le rang '1' au taches qui n'ont pas d'antécédants.
                    addedLevels++; // incrementation de nombre des taches.
                }
            }

            // mise en place les rang des autres taches.
            while(addedLevels<=taskNumbers) // tantque le nombre des taches que nous avons déja calculé ses rangs est inférieur au nombre total des taches.
            {
                foreach(var task in projectTasks) // pour chaque taches dans la liste des taches.
                {
                    if(task.antecedent.Count!=0) // si cette tache posséde des antecédants.
                    {
                        int maxLevel = 0; // comme d'habitude, pour n'importe quelle tache, on prend le maximum des rangs des antecedants + 1
                        if(ifIssetAllAntecedantsLevel(task.antecedent)) // si tous les rangs des antecedants sont calculés.
                        {
                            foreach(var antecedant in task.antecedent) // on recupére le rang et on va trouver le maximum , en le compare avec maxLevel
                            {
                                maxLevel = Math.Max(maxLevel, antecedant.taskLevel);
                            }
                            task.taskLevel = maxLevel + 1; // on ajoute 1 au maximum trouvée et on l'attache au tache courante
                            addedLevels++; // incrementation de nombre des taches.
                        }
                    }
                }
            }
        }

        /* Si tous les rangs des antécédents sont calculées.
         * Cette méthode retourne vrai si touts les rangs des antécédants données en paramétres,sinon elle retourne faux.
        */
        public bool ifIssetAllAntecedantsLevel(List<Task> antecedants)
        {
            foreach(var antecedant in antecedants)
            {
                if (antecedant.taskLevel == -1){ // si le rang = -1 (la valeur initial).
                    return false;
                }
            }
            return true;
        }

        // Si tous les dates de début au plutot des antécédents sont calculées.
        public bool ifIssetAllAntecedantsEarliestStart(List<Task> antecedants)
        {
            foreach (var antecedant in antecedants)
            {
                if (antecedant.startStep.earliestStart == -1)
                {
                    return false;
                }
            }
            return true;
        }

        // Si tous les dates de début au plutard des successeurs sont calculées.
        public bool ifIssetAllSuccessorsLatestStart(List<Task> successors)
        {
            foreach (var successor in successors)
            {
                if (successor.startStep.latestStart == -1)
                {
                    return false;
                }
            }
            return true;
        }

        // méthode retourne le maximum entier dans une listes des entiers.
        public int findMaximum(List<int> datesArray)
        {
            int maximum = datesArray[0];
            for (int i = 1; i < datesArray.Count;i++)
            {
                if(maximum<datesArray[i])
                {
                    maximum = datesArray[i];
                }
            }
            return maximum;
        }

        // méthode retourne le minimum entier dans une listes des entiers.
        public int findMinimum(List<int> datesArray)
        {
            int minimum = datesArray[0];
            for (int i = 1; i < datesArray.Count;i++)
            {
                if(minimum>datesArray[i])
                {
                    minimum = datesArray[i];
                }
            }
            return minimum;
        }

        // retourne le rang maximum.
        public int getLevelsCount()
        {
            int levelsCount = 0;
            foreach(var task in projectTasks)
            {
                if(task.taskLevel>levelsCount)
                {
                    levelsCount = task.taskLevel;
                }
            }
            return levelsCount;
        }

        // méthode qui va trouver les coordonnées X,Y basée sur les rangs des taches, elle prend la largeur max de l'interface comme paramétres.
        public void findCoordByLevel(int maxWidth) 
        {
            Random random = new Random(); // objet random : pour des entiers aléatoires.
            int coeff = maxWidth / getLevelsCount()-2; // distance calculée entre chaque 2 rangs, on divise la largeur total sur le (nombre ds rangs-2)
            foreach (var task in projectTasks) // pour chaque tache.
            {
                switch(task.taskLevel) // on prend la valeur du rang.
                {
                    case 1: // si rang == 1
                        task.finishStep.coordX = coeff;
                        task.finishStep.coordY = random.Next(50, 400); // un entier aléatoire entre 50 et 400 pour coordonné Y
                        break;
                    case 2:
                        task.finishStep.coordX = coeff*2; // pour rang 2 on multiplie le coeff par 2 et ainsi de suite ...
                        task.finishStep.coordY = random.Next(50,400);
                        break;
                    case 3:
                        task.finishStep.coordX = coeff*3;
                        task.finishStep.coordY = random.Next(50,400);
                        break;
                    case 4:
                        task.finishStep.coordX = coeff*4;
                        task.finishStep.coordY = random.Next(50,400);
                        break;
                    case 5:
                        task.finishStep.coordX = coeff*5;
                        task.finishStep.coordY = random.Next(50,400);
                        break;
                    case 6:
                        task.finishStep.coordX = coeff*6;
                        task.finishStep.coordY = random.Next(50,400);
                        break;
                    case 7:
                        task.finishStep.coordX = coeff*7;
                        task.finishStep.coordY = random.Next(50,400);
                        break;
                    default:
                        task.finishStep.coordX = 750;
                        task.finishStep.coordY = random.Next(50,400);
                        break;
                }
            }
        }

        // pour trouver les dates de début au plutot.
        public void setEarliestStart()
        {
            int calculatedEarliestStartDates = 0; // variable pour compter les taches qu'on a déja calculée ses dates au plutot.
            /* l'idée est la même que la méthode findLevels, on parcoure les dates au plutot des antécédants de chaque tache
             * S'ils sont calculées , on prend le max + la durée de la tache sinon en re-boucle.
            */
            int tasksNumber = projectTasks.Count;
            foreach(var task in projectTasks)
            {
                if (task.antecedent.Count==0)
                {
                    task.startStep.earliestStart = 0;
                    calculatedEarliestStartDates++;
                }
            }
            while(calculatedEarliestStartDates<=tasksNumber)
            {
                foreach(var task in projectTasks)
                {
                    if(task.antecedent.Count!=0)
                    {
                        if(ifIssetAllAntecedantsEarliestStart(task.antecedent))
                        {
                            List<int> earliestStartDates = new List<int>();
                            foreach(var anteced in task.antecedent)
                            {
                                earliestStartDates.Add(anteced.startStep.earliestStart+anteced.taskDuration);
                            }
                            task.startStep.earliestStart = findMaximum(earliestStartDates); // en récupére le maximum
                            calculatedEarliestStartDates++;
                        }
                    }
                }
            }

            //apres la calcule de toutes les date au plutot , on va trouver la durée total du projet a l'aide des taches qui n'ont pas de successeurs.
            List<int> findProjctDelay = new List<int>();
            foreach(var task in projectTasks)
            {
                if(task.successors.Count==0)
                {
                    findProjctDelay.Add(task.startStep.earliestStart+task.taskDuration);
                }
            }
            //List<int> numbers = new List<int>();
            /*foreach(var task in projectTasks)
            {
                numbers.Add(task.startStep.stepNumber);
                numbers.Add(task.finishStep.stepNumber);
            }*/

            //on fait appelle a la méthode findMaximum et en passe la liste des entiers pour trouver le maximum qui sera la durée total du projet.
            lastStep = new step(0,findMaximum(findProjctDelay)); // en creer la derniere étape , avec la durée total du projet.
        }


        // méthode retourne vrai si tous les taches antecédants d'une tache sont dessinées.
        public bool isPaintedAllAntecedents(List<Task> antecedent)
        {
            foreach(var task in antecedent)
            {
                if (!task.painted) return false;
            }
            return true;
        }

        // Pour chaque tache, cette méthode va rendre l'etapeDebut des successeurs de cette tache égale au etapeFin de cette tache 
        // debut ta3 les successeurs hiya la fin ta3 la tache courante bach yji rasm shih
        public void switchSteps()
        {
            foreach(var task in projectTasks)
            {
                if(task.taskLevel==1)
                {
                    task.startStep.coordX =50; // on fixe les coordonnées de l'étape début des tache de rang 1
                    task.startStep.coordY =276;
                }
                if(task.successors.Count>1)
                {
                    step sfstep = task.finishStep;
                    foreach(var successor in task.successors)
                    {
                        successor.startStep.coordX = sfstep.coordX;
                        successor.startStep.coordY = sfstep.coordY;
                    }
                }else{
                    if(task.successors.Count==1)
                    {
                        step sfstep = task.finishStep;
                        task.successors[0].startStep.coordX = sfstep.coordX;
                        task.successors[0].startStep.coordY = sfstep.coordY;
                    }else{ // <1 && !=1 : =0
                        task.finishStep.coordX = 638; // on fixe les coordonnees de l'étape fin de la derniere tache.
                        task.finishStep.coordY = 276;
                    }
                }
            }
        }


        // la même chose pour les taches qui ont plusieurs antécédants.
        public void switchStepsAnteced()
        {
            foreach(var task in projectTasks)
            {
                if(task.antecedent.Count>1)
                {
                    step _step = task.startStep;
                    foreach(var anteced in task.antecedent)
                    {
                        anteced.finishStep.coordX = _step.coordX; // la fin de l'antécédant = au début du tache courante.
                        anteced.finishStep.coordY = _step.coordY;
                    }
                }
            }
        }

        // pour calculer les dates au plutard , le même principe de la méthode setEarliestStart().
        public void setLatestStart()
        {
            int calculatedLatestStartDates = 0;
            int tasksNumber = projectTasks.Count;
            foreach(var task in projectTasks)
            {
                if (task.successors.Count == 0)
                {
                    task.startStep.latestStart = lastStep.latestStart - task.taskDuration;
                    calculatedLatestStartDates++;
                }
            }
            while(calculatedLatestStartDates<tasksNumber)
            {
                foreach(var task in projectTasks)
                {
                    if(task.startStep.latestStart==-1)
                    {
                        if (task.successors.Count != 0)
                        {
                            if (ifIssetAllSuccessorsLatestStart(task.successors))
                            {
                                List<int> latestStarttDates = new List<int>();
                                foreach (var successor in task.successors)
                                {
                                    latestStarttDates.Add(successor.startStep.latestStart - task.taskDuration);
                                }
                                task.startStep.latestStart = findMinimum(latestStarttDates);
                                calculatedLatestStartDates++;
                            }
                        }
                    }
                }
            }
        }

        // La méthode qui va calculer les marges totales pour chaque tache.
        public void findMargins() 
        {
            foreach(var task in projectTasks)
            {
                task.startStep.margin = task.startStep.latestStart - task.startStep.earliestStart;
            }
        }


        //la méthode qui cherche le chemin critique dans l'ensemble des taches.
        public List<Task> findCriticalPath()
        {
            List<Task> criticalPath = new List<Task>();
            foreach(var task in projectTasks)
            {
                if(task.startStep.margin==0)
                {
                    criticalPath.Add(task);
                }
            }

            // on ordonne les taches critique selon leurs date au plutot
            for (int i = criticalPath.Count-1; i >= 0; i--)
            {
                for (int j = 0; j < i;j++)
                {
                    if(criticalPath[j].startStep.earliestStart>criticalPath[j+1].startStep.earliestStart)
                    {
                        Task tmp = criticalPath[j + 1];
                        criticalPath[j + 1] = criticalPath[j];
                        criticalPath[j] = tmp;
                    }
                }
            }
            return criticalPath;
        }
        public void setStartEnd()
        {
            foreach(var task in projectTasks)
            {
                List<Task> list = ifExistSimilarCoords(task);
                foreach(Task t in list)
                {
                    t.color = new Color(1, 0, 0);
                }
            }
        }
        public List<Task> ifExistSimilarCoords(Task task)
        {
            List<Task> list = new List<Task>();
            foreach(var t in projectTasks)
            {
                if(t.finishStep.coordX.Equals(task.finishStep.coordX) && t.finishStep.coordY.Equals(task.finishStep.coordY) && !t.Equals(task) && t.startStep.margin==0 )
                {
                    Console.Write("Task : "+task.taskName+" - "+t.taskName);
                    Console.WriteLine();
                    list.Add(t);
                }
            }
            return list;
        }
        public bool ifExistTaskMarginZero(Task task)
        {
            foreach (var t in projectTasks)
            {
                if (t.finishStep.coordX.Equals(task.finishStep.coordX) && t.finishStep.coordY.Equals(task.finishStep.coordY) && !t.Equals(task) && t.startStep.margin == 0)
                {
                    return true;
                }
            }
            return false;
        }
        // cette méthode trouve P(X,Y) qui est le point centre entre 2 autres point pt1,pt2 pour afficher le nom de la tache et la durée et pour quelle soit lisible au niveau du graphe.
        public PointD MidPoint(PointD pt1, PointD pt2)
        {
            var midX = (pt1.X + pt2.X) / 2;
            var midY = (pt1.Y + pt2.Y) / 2;
            return new PointD(midX, midY);
        }
    }

    // class pour l'éxecution
    class MainClass
    {

        // méthode principale.
        public static void Main(string[] args)
        {
            // initialisation.
            Application.Init();
            // création de l'interface
            MainWindow win = new MainWindow();
            win.Show();
            // rendre l'interface visible.
            Application.Run();
            // on lance l'application
        }
    }
}
