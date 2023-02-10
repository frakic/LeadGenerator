import "./App.css";
import { useForm } from "react-hook-form";
import { getBusinessUsers, createUser } from "./api";
import { CreateUser } from "./models";

function App() {
  const {
    register,
    handleSubmit,
    formState: { errors },
  } = useForm({
    defaultValues: {
      firstName: "",
      lastName: "",
      email: "",
    },
  });

  return (
    <div className="App">
      <form
        onSubmit={handleSubmit((data) => {
          const user = {
            firstName: data.firstName,
            lastName: data.lastName,
            email: data.email,
          } as CreateUser;
          createUser(user);
        })}
      >
        <input
          {...register("firstName", {
            required: "First name is required",
            maxLength: 100,
          })}
          placeholder="First name"
        />
        <p>{errors.firstName?.message}</p>

        <input
          {...register("lastName", {
            required: "Last name is required",
            maxLength: 100,
          })}
          placeholder="Last name"
        />
        <p>{errors.lastName?.message}</p>

        <input
          {...register("email", {
            required: "Email is required",
            maxLength: 320,
          })}
          placeholder="Email"
        />
        <p>{errors.email?.message}</p>

        <input type="submit" value="Submit" />
      </form>
    </div>
  );
}

export default App;
