using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MathNet.Numerics.LinearAlgebra;

namespace commande_moteur
{
    class Kalman
    {
        Matrix<double> A, C, Q, R, P,  K;
        public Matrix<double> X;
        double dt = 0.01;
        public Kalman()
        {
            Double[,] a = { { 1, 0 }, { dt, 1 } }, c = { { 0, 1 } }, q = { { 1,0 }, {0, 1 } },
                r = {{ 10 } }, p = { { 10, 0 }, { 0, 10 } }, x0 = { { 0 }, { 0 } };
            A = Matrix<double>.Build.DenseOfArray(a);
            C = Matrix<double>.Build.DenseOfArray(c);
            Q = Matrix<double>.Build.DenseOfArray(q);
            R = Matrix<double>.Build.DenseOfArray(r);
            P = Matrix<double>.Build.DenseOfArray(p);
            X = Matrix<double>.Build.DenseOfArray(x0);
        }
        public Kalman(Matrix<double> A_mat, Matrix<double> C_mat,double S_noise, double M_noise,double cov)
        {
            A = A_mat;
            C = C_mat;
            Q = Matrix<double>.Build.DenseDiagonal(A.RowCount, S_noise);
            R = Matrix<double>.Build.DenseDiagonal(C.RowCount, M_noise);
            P = Matrix<double>.Build.DenseDiagonal(A.RowCount, cov);
            X = Matrix<double>.Build.Dense(A.RowCount, 1, 0);
        }
        public Kalman(Matrix<double> A_mat, Matrix<double> C_mat, Matrix<double> Q_mat, 
            Matrix<double> R_mat, Matrix<double> P_mat, Matrix<double> X0)
        {
            A = A_mat;
            C = C_mat;
            Q = Q_mat;
            R = R_mat;
            P = P_mat;
            X = X0;
        }
        public void update(double[,] Y)
        {
            X = A * X;
            P = A * P * A.Transpose() + Q;
            Matrix<double> I = Matrix<double>.Build.DenseIdentity(A.RowCount);
            Matrix<double> Ym = Matrix<double>.Build.DenseOfArray(Y);
            K = P * C.  Transpose() * (C * P * C.Transpose() + R).Inverse();
            X = X + K * (Ym - C * X);
            P = (I - K * C) * P;
        }  
    }
}
