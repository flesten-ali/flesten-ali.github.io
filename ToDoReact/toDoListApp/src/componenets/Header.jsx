import React from "react";
import styles from "../cssModules/header.module.css";
export default function Header() {
  return (
    <div>
      <h1 className={styles.header}>My ToDo List</h1>
    </div>
  );
}
