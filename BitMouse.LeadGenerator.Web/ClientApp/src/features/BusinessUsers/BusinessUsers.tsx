import { useEffect, useState } from "react";
import { BusinessUser } from "../../models";
import { getBusinessUsers as getBusinessUsersApi } from "../../api";
import { UsersTable } from "../../components";

export const BusinessUsers = () => {
  const [users, setUsers] = useState([] as BusinessUser[]);

  useEffect(() => {
    getBusinessUsersApi().then((users) => {
      setUsers(users);
    });
  });

  return (
    <>
      <h1>Our business users</h1>
      {users.length > 0 && (
        <p>
          We probably should've kept this data for ourselves, but... oh well
          ¯\_(ツ)_/¯
        </p>
      )}
      <UsersTable users={users} />
    </>
  );
};
