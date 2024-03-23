import React from "react";
import Todoitem from "./Todoitem";
import styles from "../cssModules/todolist.module.css";
export default function TodoList({ todos, setToDos }) {
  const sortedTodos = todos.slice().sort((a, b) => {
    return Number(a.done) - Number(b.done);
  });

  if (todos.length != 0) {
    return (
      <div className={styles.container}>
        {sortedTodos.map((e) => {
          return (
            <Todoitem key={e.name} item={e} todos={todos} setToDos={setToDos} />
          );
        })}
      </div>
    );
  } else {
    return <div></div>;
  }
}
