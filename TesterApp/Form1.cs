using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NLog;
using SchemaZen.Library;
using SchemaZen.Library.Command;
using SchemaZen.Library.Models;

namespace TesterApp
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
        }

        private async void buttonRun_Click(object sender, EventArgs e)
        {
            Func<ExecutionResponse> createSchemaAction = () =>
            {
                SchemaZenRunner runner = new SchemaZenRunner();
                return runner.CreateSnapshot(textBoxConnectionString.Text, textBoxDestinationDirectory.Text, true);
            };
            var response = await Task.Run(createSchemaAction);
            appendExecutionResponse(response);
        }

        private async void buttonDeploySnapshot_Click(object sender, EventArgs e)
        {
            Func<ExecutionResponse> deploySchemaAction = () =>
            {
                SchemaZenRunner runner = new SchemaZenRunner();
                return runner.DeploySnapshot(textBoxConnectionString.Text, textBoxDestinationDirectory.Text, true, true);
            };
            var response = await Task.Run(deploySchemaAction);
            appendExecutionResponse(response);
        }

        private void appendExecutionResponse(ExecutionResponse response)
        {
            textBoxLog.Text = response.Success + Environment.NewLine + response.Message + Environment.NewLine + response.Exception?.ToString();
        }
    }
}
