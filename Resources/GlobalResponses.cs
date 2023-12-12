using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackSmartTalent.Resources
{
    public class GlobalResponses
    {

        public const string LoginNombreUsuario = "El campo Nombre de Usuario es obligatorio";
        public const string LoginContraseñaUsuario = "El campo Contraseña es obligatorio";
        public const string LoginUsuarioNoEncontrado = "Usuario No encontrado";

        public const string ErrorNombreHotel = "El campo Nombre del Hotel es obligatorio";
        public const string ErrorDireccionHotel = "El campo Direccion es obligatorio";
        public const string HotelCreadoCorrectamente = "Hotel creado correctamente";
        public const string HotelActualizadoCorrectamente = "Hotel actualizado correctamente";
        public const string NoRelacionHotel = "Se debe relacionar el hotel a la habitacion";
        public const string NoRelacionHabitacion = "El ID de la habitacion es incorrecto";
        public const string PrecioHotelIncorrecto = "Valor Precio Invalido";
        public const string ImpuestoHotelIncorrecto = "Valor Impuesto Invalido";
        public const string HabitacionCreadoCorrectamente = "Habitacion creada correctamente";
        public const string HabitacionActualizadaCorrectamente = "Habitacion actualizada correctamente";
        public const string ErrorIdHotel = "El ID del hotel es incorrecto";
        public const string NoFoundHotel = "El Hotel No existe";
        public const string NoFoundRoom = "La Habitacion No existe";
        public const string CantidadPersonasCero = "La Habitacion debe permitir mas de 0 personas";

        public const string NoBooking = "No existen Reservaciones Activas";
        public const string NoHotelByCondition = "No existen Hoteles con los parametros deseados";

        public const string ReservaIdHabitacionRequerido = "No selecciono habitacion para la reservacion";
        public const string ReservaHuespedesRequerido = "Informacion del huesped es requerida";
        public const string ReservaFechasInvalidas = "La fecha es incorrecta";
        public const string ReservaCantidadPersonasInvalida = "La cantidad de personas debe ser mayor a 0";
        public const string ReservaCiudadDestinoRequerido = "La cuidad es requerida";

        public const string ReservaInsertada = "Reserva Registrada";

        public const string ErrorInterno = "Error interno al crear el hotel";
    }
}
