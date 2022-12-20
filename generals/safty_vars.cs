using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class safty_vars : MonoBehaviour
{
    public static Color[] safty_colors = { Color.green,Color.green,Color.green,
    Color.yellow,Color.yellow,Color.yellow,
    Color.red,Color.red,Color.red};
    
    public static List<string> safty_unloading_action = new List<string> {"N/A","N/A","N/A",
    "Unload all damaged levels after action time","Unload all levels after action time",
    	"Unload all levels after action time",	"Unload damaged levels before action time",
        	"Unload damaged half levels before action time","Unload damaged all levels before action time" };
    
    public static List<string> safty_timeline= new List<string>  {
"2 hours","5 hours","1 day","2 weeks",
"4 weeks","2 mounths","3 mounths","6 mounths","1 year"
};

    public static List<string>  safty_corrective_action= new List<string>  {
"Monitor",
"Instruct/train operators",
"Install protector or guard",
"Repair",
"Replace",
"Repair or replace",
"Update needed",
"Order a capacity inspection",
"Réinstaller",
};

    public static List<string> safty_using_action = new List<string> {
"Remain in service",
"Remain in service",
"Remain in service",
"In service during action timeline",
"In service during action timeline",
"In service during action timeline",
"Put out of service",
"Put out of service",
"Put out of service",
};


    public static List<string> safty_unloading_actionFR = new List<string> {"N/A","N/A","N/A",
    "Décharger les niveaux endommagés après le délai d'intervation","Décharger après le délai d'intervation",
        "Décharger après le délai d'intervation",   "Décharger avant le délai d'intervantion",
            "Décharger avant le délai d'intervation","Décharger avant le délai d'intervation" };
    
    public static List<string> safty_timelineFR= new List<string>  {
"2 Heures","5 Heures","1 jour","2 Semaines",
"4 Semaines","2 Mois","3 Mois","6 Mois","1 année"

};
    public static List<string>  safty_corrective_actionFR= new List<string> {

"Moniteur",
"Instruire/former les opérateurs",
"Installer un protecteur ou un protecteur",
"Réparer",
"Remplacer",
"Réparer ou remplacer",
"Mise à jour nécessaire",
"Commander une inspection de capacité",
"Réinstaller",
};

    public static List<string> safty_using_actionFR = new List<string> {
"Continue à utliliser",
"Continue à utliliser",
"Continue à utliliser",
"Utiliser durant le délai d'intervantion",
"Utiliser durant le délai d'intervantion",
"Utiliser durant le délai d'intervantion",
"Mettre hors service",
"Mettre hors service",
"Mettre hors service",
};
}
