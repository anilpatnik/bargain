using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Bargain.Services.Interfaces;
using Microsoft.Extensions.Logging;
using Bargain.Repositories.Interfaces;
using Bargain.Services.Common;
using Bargain.Models;

namespace Bargain.Services
{
    public class TradeService : ITradeService
    {
        private readonly ITradeRepository _tradeRepository;
        private readonly ISaveRepository _unitOfWork;        
        private readonly ILogger<TradeService> _logger;

        public TradeService(
            ITradeRepository tradeRepository, 
            ISaveRepository unitOfWork, 
            ILogger<TradeService> logger)
        {
            _tradeRepository = tradeRepository;
            _unitOfWork = unitOfWork;            
            _logger = logger;
        }

        public async Task<IEnumerable<Trade>> ListAsync(int id)
        {
            return await _tradeRepository.ListAsync(id);
        }

        public async Task<Response<Trade>> FindByIdAsync(int id)
        {
            var payload = await _tradeRepository.FindByIdAsync(id);

            return payload == null ?
                new Response<Trade>("Trade not found.") :
                new Response<Trade>(payload);
        }

        public async Task<Response<Trade>> SaveAsync(Trade payload)
        {
            try
            {
                _tradeRepository.Add(payload);

                await _unitOfWork.CompleteAsync();

                return new Response<Trade>(payload);
            }
            catch (Exception ex)
            {
                _logger.LogError($"{nameof(TradeService)} {nameof(SaveAsync)} {ex.Message}");

                return new Response<Trade>(ex.Message);
            }
        }

        public async Task<Response<Trade>> UpdateAsync(int id, Trade payload)
        {
            var existingTrade = await _tradeRepository.FindByIdAsync(id);

            if (existingTrade == null)
            {
                return new Response<Trade>("Trade not found.");
            }

            existingTrade.Name = payload.Name;

            try
            {
                _tradeRepository.Update(existingTrade);

                await _unitOfWork.CompleteAsync();

                return new Response<Trade>(existingTrade);
            }
            catch (Exception ex)
            {
                _logger.LogError($"{nameof(TradeService)} {nameof(UpdateAsync)} {ex.Message}");

                return new Response<Trade>(ex.Message);
            }
        }

        public async Task<Response<Trade>> DeleteAsync(int id)
        {
            var existingTrade = await _tradeRepository.FindByIdAsync(id);

            if (existingTrade == null)
            {
                return new Response<Trade>("Trade not found.");
            }

            try
            {
                _tradeRepository.Remove(existingTrade);

                await _unitOfWork.CompleteAsync();

                return new Response<Trade>(existingTrade);
            }
            catch (Exception ex)
            {
                _logger.LogError($"{nameof(TradeService)} {nameof(DeleteAsync)} {ex.Message}");

                return new Response<Trade>(ex.Message);
            }
        }
    }
}
