import React from "react";
import styles from "../cssModules/footer.module.css";
export default function Footer({ totCompleted, totTodos }) {
  return (
    <div className={styles.footer}>
      <h3>Number of Total tasks {totTodos}</h3>
      <h3> Number of Completed tasks {totCompleted}</h3>
    </div>
  );
}
