import * as React from "react";
import Chart from "chart.js";
import { DataFetcher } from "../Classes/DataFetcher";

export interface IDataPoint {
  time: Date;
  value: number;
}
export interface ILineChartProps {
  data: Array<IDataPoint>;
}

export default class LineChart extends React.Component<ILineChartProps> {
  private canvasRef = React.createRef<HTMLCanvasElement>();
  private myChart!: Chart;

  public componentDidMount() {
    this.SetUpChart();
  }

  private SetUpChart() {
    var fetcher = new DataFetcher();
    console.log(fetcher.GetData());

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
                  max: 30
                }
              }
            ]
          }
        },
        data: {
          labels: this.props.data.map(d => d.time.toUTCString()),
          datasets: [
            {
              data: this.props.data.map(d => d.value),
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
