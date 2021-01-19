# test_encoder_R4_UI
Revision 4 of testing encoder


Ce projet correspond au test de la logique du programme qui sert à tester les encodeurs numériques relatifs face au traditionnel vis sans fin et limite.

Le projet est séparé en deux, soit la logique du programme et la gestion de son interface:

1. La logique est une fonction qui s'exécute en permanence. Dans cette fonction, il y a un switch case qui est concu selon une machine à état 
   qui répond à la demande des exigences de la logique du tableau explicatif "Test encoder ou limits_R4.xlsx" 
   (google sheet = https://drive.google.com/file/d/1PX_IkKNXNo9PbqIwSbJYZ03ocUUfGA5K/view).
   Elle intègre la création de fichiers .csv qui permet de garder en mémoire le nombre de pulse et d'index lors d'un demi-cycle.
   Puisque ce projet est fonctionnel seulement sur windows, il n'intègre pas la gestion du GPIO. Les entrées sont seulement données en tant que variable d'entrée de la fonction.

2. L'interface est concu avec WPF. Il intrègre cinq boutons d'entrés, soit Limite ouverte, Limite fermé, index, pulse et Changlu blackbox.
   Il fonctionne en deux temps, noir indiquant un 0 V (volts) et vert indiquant un 3,3 V. Cela correspond au 0 et 1 numérique.
   Il y a 3 autres boutons : Le bouton "remise à zéro" permet de recommencer les test sans avoir à fermer et redémarrer le logiciel. 
   Le bouton "rafraichir les sorties" permet d'afficher les dernières valeurs calculées par le programme. Le bouton "sauvegarder et quitter" permet de fermer proprement
   le logiciel en fermant le fichier .csv dans laquel le programme écrit.
    
