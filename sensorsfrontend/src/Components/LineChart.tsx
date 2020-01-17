import * as React from "react";
import Chart from "chart.js";

export interface ILineChartProps {}

export default class LineChart extends React.Component<ILineChartProps> {
  private canvasRef = React.createRef<HTMLCanvasElement>();
  private myChart!: Chart;

  public componentDidMount() {
    this.SetUpChart();
  }

  private SetUpChart() {
    if (this.canvasRef.current) {
      this.myChart = new Chart(this.canvasRef.current, {
        type: "line",
        options: {
          maintainAspectRatio: false,
          scales: {
            yAxes: [
              {
                ticks: {
                  min: 0,
                  max: 100
                }
              }
            ]
          }
        },
        data: {
          labels: ["A", "B", "C", "D", "E"],
          datasets: [
            {
              label: "My data",
              data: [10, 20, 30, 40, 50],
              backgroundColor: "#112233",
              fill: "none",
              pointRadius: 2,
              borderWidth: 1,
              lineTension: 1
            }
          ]
        }
      });
    }
  }
  public render() {
    return <canvas ref={this.canvasRef} />;
  }
}
