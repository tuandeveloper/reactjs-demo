export function TextInput(props) {
  return (
    <input type="text" className="form-control" value={props.value} onChange={props.onChange} />
  )
};