using System.Net;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc.Testing;
using MyTestableApi.api.Controllers;
using Xunit;

namespace MyTestableApi.Tests;

public class UnitDevises
{

    [Fact]
    //Je teste le scénario "Je récupère la devise d'un Pays existant"
    public async Task IsGetDeviseFromPaysOK()
    {
        await using var _factory = new WebApplicationFactory<Program>();
        var client = _factory.CreateClient();

        var response = await client.GetAsync("Devises?pays=Maroc");
        string stringResponse = await response.Content.ReadAsStringAsync();

        response.EnsureSuccessStatusCode();

        //Assert.True(response.StatusCode.ToString().Equals("OK"));
        Assert.Equal("La Devise du pays : Maroc est le/la : Dirham marocain, il/elle vaut 0,092 euros.", stringResponse);

    }


    //Je teste le scénario "Je demande la devise d'un Pays inconnu"
    [Fact]
    public async Task GetDeviseFromPaysNotKnown()
    {
        await using var _factory = new WebApplicationFactory<Program>();
        var client = _factory.CreateClient();

        var response = await client.GetAsync("Devises?pays=Tatooine");
        string stringResponse = await response.Content.ReadAsStringAsync();

        //Assert.True(response.StatusCode.ToString().Equals("OK"));
        Assert.Equal("Le pays donné n'existe pas", stringResponse);

    }
}