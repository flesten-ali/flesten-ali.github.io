import React from "react";
import styles from "../cssModules/todoitem.module.css";
export default function ({ item, todos, setToDos }) {
  function handleClicking(item) {
    setToDos(
      todos.filter((ele) => {
        return ele !== item;
      })
    );
  }
  function handleStatus(name) {
    setToDos(
      todos.map((todo) => {
        return todo.name === name ? { ...todo, done: !todo.done } : todo;
      })
    );
  }
  const completedClass = item.done ? styles.done : "";

  return (
    <div className={styles.item}>
      {" "}
      <h1 className={completedClass} onClick={() => handleStatus(item.name)}>
        {item.name}
      </h1>
      <button onClick={() => handleClicking(item)}>x</button>
    </div>
  );
}
