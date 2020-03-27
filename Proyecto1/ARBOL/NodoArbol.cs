using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto1.ARBOL
{
    class NodoArbol
    {
        //mtodos set y get
        NodoArbol  getNodoAnterior()
        {
            return this.nodoAtnerior; 
        }
        void setNodoAnterior(NodoArbol _nodoAnterior)
        {
            this.nodoAtnerior = _nodoAnterior;
        }
        NodoArbol getNodoSiguiente()
        {
            return this.nodoSiguiente;
        }
        void setNodoSiguiente(NodoArbol _nodoSiguiente)
        {
            this.nodoSiguiente = _nodoSiguiente;
        }
        public void setprimero(int _primero)
        {
            this.primero = _primero;
        }
        int getPrimero()
        {
            return this.primero;
        }
        public void setUltimo(int _ultimo)
        {
            this.ultimo = _ultimo;
        }
        int getUltimo()
        {
            return this.ultimo;
        } 
        public void setToken(string _token)
        {
            this.token = _token;
        }
        string getToken()
        {
            return token;
        }




        private NodoArbol nodoAtnerior;
        private NodoArbol nodoSiguiente;
        private int primero;
        private int ultimo;
        private string token;

    }
}
