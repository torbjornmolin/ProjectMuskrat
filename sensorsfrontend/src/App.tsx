import React from "react";
import "./App.css";
import LineChart from "./Components/LineChart";

const App: React.FC = () => {
  const props = [
    {
      time: new Date("2020-01-02 10:45"),
      value: 20
    },
    {
      time: new Date("2020-01-02 11:45"),
      value: 22.3
    },
    {
      time: new Date("2020-01-02 13:45"),
      value: 23.6
    },
    {
      time: new Date("2020-01-02 14:45"),
      value: 14.1
    }
  ];

  return <LineChart data={props} />;
};

export default App;
