namespace BudgetMan.Controllers
{
    using Domain;
    using Service;
    using Microsoft.AspNetCore.Mvc;

    /// <summary>
    /// Controller for BudgetMan
    /// </summary>
    [ApiController]
    [Route("v1.0/[controller]")]
    public class BudgetManController : ControllerBase
    {
        private readonly IBudgetManService _service;
        /// <summary>
        /// Constructor for BudgetMan
        /// </summary>
        /// <param name="budgetManService"></param>
        public BudgetManController(IBudgetManService budgetManService)
        {
            _service = budgetManService;
        }

        /// <summary>
        /// Prints a hello message
        /// </summary>
        /// <returns></returns>
        [HttpGet("Hello")]
        public string SayHello()
        {
            return "Welcome to BudgetMan Service";
        }

        /// <summary>
        /// Returns the Actual Period
        /// </summary>
        /// <returns></returns>
        [HttpGet("Actual")]
        public ActionResult<PeriodModel> GetActual()
        {
            PeriodModel response = _service.GetActual();
            return Ok(response);
        }

    };
}