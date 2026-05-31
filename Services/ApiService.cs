using Parcial1Cejas.Model;
using System.Net;
using System.Net.Http.Json;

// Desde este documento el codigo se comunica con la API

namespace Parcial1Cejas.Services
{
    public class ApiService
    {
        private HttpClient _httpClient = new HttpClient();

        private const string GET_URL = "https://www.freetogame.com/api/games";
        private const string POST_URL = "https://jsonplaceholder.typicode.com/posts";

        // Aca se ejecuta la accion de GET usando la API FreeToGame
        public async Task<List<Game>> GetGames()
        {
            var response = await _httpClient.GetAsync(GET_URL);

            if (response.StatusCode == HttpStatusCode.OK)
            {
                // Aca se leen los datos de la API real FreeToGame
                var apiGames = await response.Content.ReadFromJsonAsync<List<ApiGame>>();

                if (apiGames == null)
                    return new List<Game>();

                // Usando esto se puede mostrar en pantalla una plantilla simple con los datos del juego
                return apiGames.Select(g => new Game
                {
                    Name = g.title,
                    Genre = g.genre,
                    Developer = g.developer,
                    Publisher = g.publisher
                }).ToList();
            }

            throw new Exception($"Error HTTP: {response.StatusCode}");
        }

        // Desde aca se hace el POST usando la API JSONPlaceholder
        public async Task AddGame(Game game)
        {
            var response = await _httpClient.PostAsJsonAsync(POST_URL, game);

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception($"Error al guardar: {response.StatusCode}");
            }
        }
    }
}