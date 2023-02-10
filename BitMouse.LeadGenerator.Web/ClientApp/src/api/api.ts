const callApi = (method: string, url: string, variables?: any) => {
  const apiUrl = url.startsWith("/")
    ? import.meta.env.VITE_APP_API_URL + url
    : url;

  return new Promise((resolve, reject) => {
    fetch(apiUrl, {
      method: method,
      body: method !== "GET" ? JSON.stringify(variables) : undefined,
      mode: "cors",
      headers: {
        "Content-Type": "application/json",
      },
    }).then(
      (response) => {
        resolve(response.json());
      },
      (error) => {
        if (error.response) {
          reject(error.response.data.error || error.response.data.errors);
        } else {
          reject({
            code: "INTERNAL_ERROR",
            message: "An error occurred. Check your internet connection.",
            status: 503,
            data: {},
          });
        }
      }
    );
  });
};

export const api = {
  get: (url: string, variables?: any) => callApi("GET", url, variables),
  post: (url: string, variables?: any) => callApi("POST", url, variables),
  put: (url: string, variables?: any) => callApi("PUT", url, variables),
  patch: (url: string, variables?: any) => callApi("PATCH", url, variables),
  delete: (url: string, variables?: any) => callApi("DELETE", url, variables),
};
