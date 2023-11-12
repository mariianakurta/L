using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ALevelHomework9
{
    class Actions
    {
        private readonly ILogger logger;

        public Actions(ILogger logger)
        {
            this.logger = logger;
        }

        public void StartMethod()
        {
            logger.LogInfo("Start method: StartMethod");
        }

        public void BusinessException()
        {
            logger.LogWarning("Business Exception - Skipped logic in method");
            throw new BusinessException("Skipped logic in method");
        }

        public void BreakLogic()
        {
            logger.LogError("I broke a logic");
            throw new Exception("I broke a logic");
        }
    }
}
