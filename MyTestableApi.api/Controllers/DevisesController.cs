using Microsoft.AspNetCore.Mvc;

namespace MyTestableApi.api.Controllers;

[ApiController]
[Route("[controller]")]
public class DevisesController : ControllerBase
{
    private readonly ILogger<DevisesController> _logger;

    public DevisesController(ILogger<DevisesController> logger)
    {
        _logger = logger;
    }

    private List<DevisesModel> DevisePaysList = new List<DevisesModel>(){
        new DevisesModel { Pays = "Maroc", Devise = "Dirham marocain", Valeur = "0,092" },
        new DevisesModel { Pays = "Canada", Devise = "Dollar canadien", Valeur = "0,69" },
        new DevisesModel { Pays = "Nouvelle-Zélande", Devise = "Dollar néo-zélandais", Valeur = "0,55" }
    };
    
    [HttpGet(Name ="GetDevise")]
    public IActionResult Get(string pays)
    {
        if (string.IsNullOrWhiteSpace(pays)){
            return BadRequest("Veuillez rentrer un pays");
        }
        var paysInfo = DevisePaysList.Find(p => p.Pays.Equals(pays, StringComparison.OrdinalIgnoreCase));

        if (paysInfo == null)
        {
            return NotFound("Le pays donné n'existe pas");
        }
        return Ok($"La Devise du pays : {paysInfo.Pays} est le/la : {paysInfo.Devise}, il/elle vaut {paysInfo.Valeur} euros.");
    }


}
