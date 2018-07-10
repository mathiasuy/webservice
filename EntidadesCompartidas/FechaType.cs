using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EntidadesCompartidas
{
    public class FechaType
    {
        private DateTime _fecha;
        private string _fechaTipo;
        private string _fechaCorta;
        private string _fechaUniversal;

        public DateTime Fecha
        {
            get
            {
                return _fecha;
            }
            set
            {
                _fecha = value;
                _fechaTipo = value.Year + "-" + value.Month + "-" + value.Day + "T" + value.Hour + ":" + value.Minute + ":" + value.Second + "-02:00";
                _fechaCorta = value.Year + "-" + value.Month + "-" + value.Day;
            }
        }

        public string FechaTHora
        {
            get 
            {
                return _fechaTipo;
            }
        }

        public string FechaCorta
        {
            get
            {
                return _fechaCorta;
            }
        }

        public string FechaUniversal
        {
            set
            {
                _fecha = DateTime.Parse(value);
                _fechaTipo = _fecha.Year + "-" + _fecha.Month + "-" + _fecha.Day + "T" + _fecha.Hour + ":" + _fecha.Minute + ":" + _fecha.Second + "-02:00";
                _fechaCorta = _fecha.Year + "-" + _fecha.Month + "-" + _fecha.Day;
            }
            get
            {
                return _fecha.GetDateTimeFormats('u').ToString();
            }
        }

        public FechaType()
        {
            Fecha = DateTime.Now;
            _fechaTipo = Fecha.Year + "-" + Fecha.Month + "-" + Fecha.Day + "T" + Fecha.Hour + ":" + Fecha.Minute + ":" + Fecha.Second + "-02:00";
            _fechaCorta = Fecha.Year + "-" + Fecha.Month + "-" + Fecha.Day;
        }

        public FechaType(DateTime fecha)
        {
            Fecha = fecha;
            _fechaTipo = fecha.Year + "-" + fecha.Month + "-" + fecha.Day + "T" + fecha.Hour + ":" + fecha.Minute + ":" + fecha.Second + "-02:00";
            _fechaCorta = fecha.Year + "-" + fecha.Month + "-" + fecha.Day;
        }

        public override string ToString()
        {
            return FechaTHora;
        }
    }
}
