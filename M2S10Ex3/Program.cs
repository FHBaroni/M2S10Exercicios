void ExemploGet()
{
    Console.WriteLine("Exemplo utilização http client - verbo GET - Deck of Cards api");

    using var client = new HttpClient();

    var request = new HttpRequestMessage(
        HttpMethod.Get,
        "http://deckofcardsapi.com/api/deck/new/shuffle/?deck_count=1"
    );

    Console.WriteLine("-- Requisição get");

    using var response = client.Send(request);

    Console.WriteLine($"Retorno: ");
    Console.WriteLine($"Status Code: {response.StatusCode}");
    Console.WriteLine($"Corpo: {response.Content.ReadAsStringAsync().Result}");
    Console.WriteLine($"Headers: {string.Join(',', response.Headers.Select(h => $"{h.Key}={string.Join(',', h.Value)}"))}");
}

ExemploGet();
