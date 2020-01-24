import { IDataPoint } from "../Components/LineChart";
import { resolveNaptr } from "dns";

export class DataFetcher {
  async GetData(): Promise<Array<IDataPoint>> {
    var returnValue: Array<IDataPoint>;
    var apiData = await this.DoFetch();
    return apiData.map((d: { savedAd: Date; value: number }) => {
      return { time: d.savedAd, value: d.value };
    });
  }
  private DoFetch(): Promise<any> {
    return fetch(
      "http://192.168.1.2:90/api/sensorvalue/by/date/2020-01-24"
    ).then(response => {
      console.log(response);
      return response.json();
    });
  }
}
