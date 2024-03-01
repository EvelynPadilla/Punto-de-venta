using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Punto_de_Venta_Panaderia
{
    
   
        public class CarritoViewModel : INotifyPropertyChanged
        {
            public ObservableCollection<Producto> Productos { get; set; } = new ObservableCollection<Producto>();

            private decimal total;
            public decimal Total
            {
                get => total;
                private set
                {
                    total = value;
                OnPropertyChanged(nameof(Total));
                }
            }

            private decimal efectivo;
            public decimal Efectivo
            {
                get => efectivo;
                set
                {
                    efectivo = value;
                    CalcularCambio();
                }
            }

            private decimal cambio;
            public decimal Cambio
            {
                get => cambio;
                private set
                {
                    cambio = value;
                    OnPropertyChanged(nameof(Cambio));
                }
            }

            public void AgregarProducto(Producto producto)
            {
                Productos.Add(producto);
                CalcularTotal();
            }

            public void EliminarProducto(Producto producto)
            {
                Productos.Remove(producto);
                CalcularTotal();
            }

            public void ProcesarPago()
            {
                if (Efectivo >= Total)
                {
                    Cambio = Efectivo - Total;
        
                }
                else
                {
                    // El efectivo no es suficiente para cubrir el total.
                    
                    Cambio = 0;
                }
            }

            private void CalcularTotal()
            {
                Total = Productos.Sum(p => p.Precio);
                CalcularCambio();
            }

            private void CalcularCambio()
            {
                Cambio = Efectivo - Total;
            }


            public event PropertyChangedEventHandler? PropertyChanged;

            
        }
    }


