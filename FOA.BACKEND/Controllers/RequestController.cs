using FOA.BACKEND.Business.DTO;
using FOA.BACKEND.Business.Interfaces.Services;
using FOA.BACKEND.Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FOA.BACKEND.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RequestController : ControllerBase
    {
        private readonly IRequestService _requestService;

        public RequestController(IRequestService requestService)
        {
            _requestService = requestService;
        }

        [HttpGet("{requestId}")]
        public async Task<ActionResult<RequestDTO>> GetRequestById(int requestId)
        {
            var request = await _requestService.GetRequestByIdAsync(requestId);
            if (request == null)
            {
                return NotFound();
            }

            var requestDTO = new RequestDTO
            {
                UserId = request.UserId,
                Title = request.Title,
                Message = request.Message,
                Priority = request.Priority,
                IsActive = request.IsActive
            };

            return Ok(requestDTO);
        }

        [HttpGet("user/{userId}/active")]
        public async Task<ActionResult<List<RequestDTO>>> GetActiveRequests(string userId)
        {
            var requests = await _requestService.GetActiveRequestsAsync(userId);

            var requestDTOs = new List<RequestDTO>();
            foreach (var request in requests)
            {
                var requestDTO = new RequestDTO
                {
                    UserId = request.UserId,
                    Title = request.Title,
                    Message = request.Message,
                    Priority = request.Priority,
                    IsActive = request.IsActive
                };
                requestDTOs.Add(requestDTO);
            }

            return Ok(requestDTOs);
        }

        [HttpPost]
        public async Task<ActionResult<RequestDTO>> CreateRequest(RequestDTO requestDTO)
        {
            var request = new Request
            {
                UserId = requestDTO.UserId,
                Title = requestDTO.Title,
                Message = requestDTO.Message,
                Priority = requestDTO.Priority,
                IsActive = requestDTO.IsActive
            };

            var createdRequest = await _requestService.CreateRequestAsync(request);

            var createdRequestDTO = new RequestDTO
            {
                UserId = createdRequest.UserId,
                Title = createdRequest.Title,
                Message = createdRequest.Message,
                Priority = createdRequest.Priority,
                IsActive = createdRequest.IsActive
            };

            return CreatedAtAction(nameof(GetRequestById), new { requestId = createdRequest.Id }, createdRequestDTO);
        }

        [HttpPut("{requestId}")]
        public async Task<ActionResult<RequestDTO>> UpdateRequest(int requestId, RequestDTO requestDTO)
        {

            var existingRequest = await _requestService.GetRequestByIdAsync(requestId);
            if (existingRequest == null)
            {
                return NotFound();
            }

            existingRequest.Title = requestDTO.Title;
            existingRequest.Message = requestDTO.Message;
            existingRequest.Priority = requestDTO.Priority;
            existingRequest.IsActive = requestDTO.IsActive;

            var updatedRequest = await _requestService.UpdateRequestAsync(existingRequest);
            if (updatedRequest == null)
            {
                return NotFound();
            }

            var updatedRequestDTO = new RequestDTO
            {
                Title = updatedRequest.Title,
                Message = updatedRequest.Message,
                Priority = updatedRequest.Priority,
                IsActive = updatedRequest.IsActive
            };

            return Ok(updatedRequestDTO);
        }

        [HttpDelete("{requestId}")]
        public async Task<IActionResult> DeleteRequest(int requestId)
        {
            var existingRequest = await _requestService.GetRequestByIdAsync(requestId);
            if (existingRequest == null)
            {
                return NotFound();
            }

            await _requestService.DeleteRequestAsync(requestId);

            return NoContent();
        }
    }
}
