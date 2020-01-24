import * as React from "react";
import Chart from "chart.js";
import { DataFetcher } from "../Classes/DataFetcher";

export interface IDataPoint {
  time: Date;
  value: number;
}
export interface ILineChartProps {
  data: Promise<Array<IDataPoint>>;
}

export default class LineChart extends React.Component<ILineChartProps> {
  private canvasRef = React.createRef<HTMLCanvasElement>();
  private myChart!: Chart;

  public componentDidMount() {
    this.SetUpChart();
  }

  private SetUpChart() {
    var fetcher = new DataFetcher();
    fetcher.GetData().then(d => {
      console.log("GetData:");
      console.log(d);
      this.RenderCanvas(d);
    });
  }
  private RenderCanvas(data: IDataPoint[]) {
    if (this.canvasRef.current) {
      this.myChart = new Chart(this.canvasRef.current, {
        type: "line",
        options: {
          maintainAspectRatio: false,
          scales: {
            xAxes: [
              {
                type: "time",
                time: {
                  unit: "day"
                }
              }
            ],
            yAxes: [
              {
                ticks: {
                  min: -15,
                  max: 80
                }
              }
            ]
          }
        },
        data: {
          labels: data.map(d => new Date(d.time).toISOString()),
          datasets: [
            {
              data: data.map(d => d.value),
              fill: "none",
              label: "Temperature",
              backgroundColor: "#ff9999"
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
