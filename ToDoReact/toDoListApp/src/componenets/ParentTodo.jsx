import React, { useState } from "react";
import Form from "./Form";
import TodoList from "./TodoList";
import Footer from "./Footer";

export default function ParentTodo() {
  const [todos, setToDos] = useState([]);
  const totCompleted = todos.filter((e) => {
    return e.done;
  }).length;
  const totTodos = todos.length;
  return (
    <div>
      <Form todos={todos} setToDos={setToDos} />
      <TodoList todos={todos} setToDos={setToDos} />
      <Footer totCompleted={totCompleted} totTodos={totTodos} />
    </div>
  );
}
