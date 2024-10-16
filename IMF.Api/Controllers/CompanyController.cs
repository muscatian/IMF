using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using System;
using IMF.DAL.Repository.IRepository;
using IMF.DAL.Models.Common;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using IMF.Api.DTO.Common;
using AutoMapper;

namespace IMF.Api.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyController : ControllerBase
    {
        private readonly ILogger<CompanyController> _logger;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CompanyController( ILogger<CompanyController> logger, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        [Authorize]
        [HttpGet("GetCompanies")]
        public async Task<ActionResult<List<CompanyDTO>>> GetAll()
        {
            try
            {
                var objCompanyList = await _unitOfWork.Company.GetAllAsync();
                var companyDtoList = _mapper.Map<List<CompanyDTO>>(objCompanyList);
                return Ok(companyDtoList);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return BadRequest($"An error has occurred => {ex.Message}");
            }
        }

        [Authorize]
        [HttpPost("SaveCompany")]
        [Route("api/company")]
        public async Task<ActionResult<CompanyDTO>> PostCompany(CompanyDTO companyDto)
        {
            try
            {
                var company = _mapper.Map<Company>(companyDto);
                _unitOfWork.Company.Add(company);
                await _unitOfWork.SaveChangesAsync();

                //company = await _unitOfWork.Company.GetAsync(c => c.Id == company.Id);
                companyDto = _mapper.Map<CompanyDTO>(company);

                return CreatedAtAction(nameof(GetCompany), new { id = company.Id }, companyDto);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return BadRequest($"An error has occurred => {ex.Message}");
            }

        }

        [HttpGet("GetCompany")]
        public async Task<ActionResult<CompanyDTO>> GetCompany(int id)
        {
            try
            {
                var company = await _unitOfWork.Company.GetAsync(c => c.Id == id);

                var companyDto = _mapper.Map<CompanyDTO>(company);

                if (company == null)
                {
                    return NotFound();
                }
                return Ok(companyDto);

            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return BadRequest($"An error has occurred => {ex.Message}");
            }
        }
    }
}
