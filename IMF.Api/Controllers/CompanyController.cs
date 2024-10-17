using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using System;
using IMF.DAL.Repository.IRepository;
using IMF.DAL.Models.Common;
using System.Collections.Generic;
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

        public CompanyController(ILogger<CompanyController> logger, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

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

        [Authorize(Roles = "SystemAdmin, CompanyAdmin")]
        [HttpPost("SaveCompany")]
        [Route("api/company")]
        public async Task<ActionResult<CompanyDTO>> PostCompany(CompanyDTO companyDto)
        {
            try
            {
                var company = _mapper.Map<Company>(companyDto);
                _unitOfWork.Company.Add(company);
                await _unitOfWork.SaveChangesAsync();

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

        [Authorize(Roles = "SystemAdmin, CompanyAdmin")]
        [HttpPut("UpdateCompany")]
        public async Task<ActionResult<CompanyDTO>> UpdateCompany(int id, CompanyDTO companyDto)
        {
            if (id != companyDto.Id)
            {
                return BadRequest("Mismatched company ID");
            }

            try
            {
                var company = await _unitOfWork.Company.GetAsync(c => c.Id == id);
                if (company == null)
                {
                    return NotFound();
                }

                _mapper.Map(companyDto, company);
                _unitOfWork.Company.Update(company);
                await _unitOfWork.SaveChangesAsync();

                companyDto = _mapper.Map<CompanyDTO>(company);

                return Ok(companyDto); // Returning the updated company
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return BadRequest($"An error has occurred => {ex.Message}");
            }
        }

        [Authorize(Roles = "DeleteAdmin")]
        [HttpDelete("DeleteCompany")]
        public async Task<IActionResult> DeleteCompany(int id)
        {
            try
            {
                var company = await _unitOfWork.Company.GetAsync(c => c.Id == id);
                if (company == null)
                {
                    return NotFound();
                }

                _unitOfWork.Company.Remove(company);
                await _unitOfWork.SaveChangesAsync();

                return Ok($"Company  {company.Name} has been deleted successfully");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return BadRequest($"An error has occurred => {ex.Message}");
            }

        }
    }
}