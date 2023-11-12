using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ALevelHomework9
{
    class App
    {
        private ILogger logger;
        private IFileService fileService;
        private Actions actions;
        private Random random;

        public App(Actions actions, ILogger logger, IFileService fileService)
        {
            this.actions = actions;
            this.logger = logger;
            this.fileService = fileService;
            random = new Random();
        }

        public void Run(int iterations, string collections)
        {
            for (int i = 0; i < iterations; i++)
            {
                int actionIndex = random.Next(1, 4); 

                try
                {
                    switch (actionIndex)
                    {
                        case 1:
                            actions.StartMethod();
                            break;
                        case 2:
                            actions.BusinessException();
                            break;
                        case 3:
                            actions.BreakLogic();
                            break;
                    }
                }
                catch (BusinessException ex)
                {
                    logger.LogWarning($"Action got this custom Exception: {ex.Message}");
                }
                catch (Exception ex)
                {
                    logger.LogError($"Action failed by reason: {ex.ToString()}");
                }

                string logContent = $"{DateTime.Now.ToString("MM/dd/yyyy hh:mm:ss.fff tt")}: {logger.ToString()}";
                fileService.WriteToFile(collections, $"{DateTime.Now:MM-dd-yyyy_hh-mm-ss-fff_tt}", logContent);
                fileService.FilesControl(collections);
            }
        }
    }
}
