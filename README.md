# c# Filtre de Kalman

Ceci est une classe que j'ai creé en c# dans le cadre d'un projet robotique.  
  
Il faut utiliser la librairie MathNet Numerics pour pouvoir l'implémenter dans votre code.  
  
# Instanciation
Il y a 3 possibilités pour instancier le filtre  
* Soit avec les paramètres par défauts
* Soit en utilisant vos propres matrices d'état et d'observation. Il faut alors donner les valeurs des bruits de mésure,d'états et la covariance des érreurs.
* Soit en créant tous les matrices et les utiliser pour instancier la classe.
  
Exemple:  
double[,] a = { { 1, 0, 0, 0 },   
                { 0, 1, 0, 0 },   
                { dt, 0, 1, 0 },   
                { 0, dt, 0, 1 } },  
                  
double[,]c = { { 0, 0, 1, 0 },   
                { 0, 0, 0, 1 } };    
Matrix<double> A = Matrix<double>.Build.DenseOfArray(a);  
Matrix<double> C = Matrix<double>.Build.DenseOfArray(c);  
filter = new Kalman(A, C, 10, 100000, 100);  
    
# Utilisation  
Une fois le filtre instancier, il suffit de mettre vos mésures dans un tableau de taille (nx1) (n: nombre d'états mesurés) et d'utiliser la méthode update du filtre pour filtrer vos mésures.  
  
Exemple:   
  
double[,] Mesures = { { mesure[0] }, { mesure[1] } };  
filter.update(Mesures);  
double Fmesure[0] = filter.X[2,0];  
double Fmesure[1] = filter.X[3,0];  
