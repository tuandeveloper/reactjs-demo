import React, {useEffect, useState} from 'react';

export const Counter = () => {
  const [count, setCount] = useState(0);

  console.log("test re-render");

  useEffect(() => {
    console.log('use effect !');
  }, []);

  return (
    <div>
      <p>You clicked {count} times</p>
      <button onClick={() => setCount(count + 1)}>
        Click me
      </button>
    </div>
  );
};