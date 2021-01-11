import { useState } from "react";
import { TextInput } from "../components/TextInput";

export function Test() {
  const [firstName, setFirstName] = useState('');

  return (
    <div className="form-horizontal">
      <div className="form-group">
        <label className="control-label col-2">First Name</label>
        <div className="col-6">
          <TextInput value={firstName} onChange={e => setFirstName(e.target.value)} />
        </div>
      </div>
      <div className="form-group">
        <label>{firstName}</label>
      </div>
    </div>
  )
}