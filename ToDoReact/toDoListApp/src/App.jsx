import { useState } from "react";
import Header from "./componenets/header";
import "./App.css";
import ParentTodo from "./componenets/ParentTodo";
function App() {
  const [count, setCount] = useState(0);

  return (
    <div className="App">
      <Header />
      <ParentTodo />
    </div>
  );
}

export default App;
