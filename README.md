# c# Filtre de Kalman

Ceci est une classe que j'ai creé en c# dans le cadre d'un projet robotique.

Il faut utiliser la librairie MathNet Numerics pour pouvoir l'implémenter dans votre code.

# Instanciation
Il y a 3 possibilités pour instancier le filtre
-Soit avec les paramètres par défauts
-Soit en utilisant vos propres matrices d'état et d'observation. Il faut alors donner les valeurs des bruits de mésure,d'états et la covariance des érreurs.
-Soit en créant tous les matrices et les utiliser pour instancier la classe
