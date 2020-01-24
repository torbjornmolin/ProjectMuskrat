import { IDataPoint } from "../Components/LineChart";

export class DataFetcher {
  async GetData(): Promise<Array<IDataPoint>> {
    var apiData = await this.DoFetch();
    return apiData.map((d: { savedAt: Date; value: number }) => {
      return { time: d.savedAt, value: d.value };
    });
  }
  private async DoFetch(): Promise<any> {
    const response = await fetch(
      "http://192.168.1.2:90/api/sensorvalue/by/date/2020-01-24"
    );
    return response.json();
  }
}
