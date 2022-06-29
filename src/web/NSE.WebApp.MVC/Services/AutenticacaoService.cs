﻿using System.Text;
using System.Text.Json;
using NSE.WebApp.MVC.Models;

namespace NSE.WebApp.MVC.Services;

public class AutenticacaoService : IAutenticacaoService
{
    private readonly HttpClient _httpClient;

    public AutenticacaoService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }
    public async Task<string> Login(UsuarioLogin usuarioLogin)
    {
        var loginContent = new StringContent(
            JsonSerializer.Serialize(usuarioLogin),
            Encoding.UTF8,
            "application/json");

        string url = "https://localhost:7209/api/identidade/autenticar";

        var response = await _httpClient.PostAsync(url, loginContent);

        return JsonSerializer.Deserialize<string>(await response.Content.ReadAsStringAsync());
    }

    public Task<string> Registro(UsuarioRegistro usuarioRegistro)
    {
        throw new NotImplementedException();
    }
}