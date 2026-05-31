//En este archivo se van a poder ver los juegos agregados 
//mediante el uso de un mensaje

using Parcial1Cejas.Model;

namespace Parcial1Cejas.Messages
{
    public class GameAddedMessage
    {
        public Game Game { get; set; }
    }
}