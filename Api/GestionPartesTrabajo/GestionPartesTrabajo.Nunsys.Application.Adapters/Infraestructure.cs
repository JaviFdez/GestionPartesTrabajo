using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionPartesTrabajo.Nunsys.Application.Adapters
{
    /// <summary>
    /// Modelo con una propiedad
    /// </summary>
    /// <typeparam name="T">Tpo de valor para la propiedad</typeparam>
    public class PropertyModel<T>
    {
        /// <summary>Nombre de la propiedad</summary>
        public string PropertyName { get; set; }

        /// <summary>Valor de la propiedad</summary>
        public T PropertyValue { get; set; }
    }

    /// <summary>
    /// Modelo para implementar un filtro generico para un rango de valores con orden de clasificacion (Elementos ordenados)
    /// </summary>
    public class RangeFilterModel<T>
    {
        /// <summary>Indice incial del rango</summary>
        public T Start { get; set; }
        /// <summary>Indice final del rango</summary>
        public T End { get; set; }
    }
}
