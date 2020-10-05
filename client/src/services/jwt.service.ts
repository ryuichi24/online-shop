const TOKEN_KEY = 'token';

const jwtService = {
  getToken: () => {
    return localStorage.getItem(TOKEN_KEY);
  },

  saveToken: (token: string) => {
    localStorage.setItem(TOKEN_KEY, token);
  },

  destroyToken: () => {
    localStorage.removeItem(TOKEN_KEY);
  },
};

export default jwtService;