import React from "react";
import { useState } from "react";
import styels from "../cssModules/form.module.css";
export default function Form({ todos, setToDos }) {
  const [todo, setToDo] = useState({ name: "", done: false });

  function handleSubmit(e) {
    e.preventDefault();
    if (todo.name !== "") {
      setToDos([...todos, todo]);
      setToDo({ name: "", done: false });
    } else {
      alert("please add a task!");
    }
  }
  return (
    <form action="" onSubmit={handleSubmit}>
      <input
        onChange={(e) => setToDo({ name: e.target.value, done: false })}
        type="text"
        name=""
        id=""
        value={todo.name}
        placeholder="Enter To Do Item"
      />
      <button type="submit">Add</button>
    </form>
  );
}
