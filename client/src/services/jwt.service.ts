const TOKEN_KEY = 'token';
const ADMIN_TOKEN_KEY = 'adminToken';

const jwtService = {
  getToken: () => localStorage.getItem(TOKEN_KEY),

  saveToken: (token: string) => {
    localStorage.setItem(TOKEN_KEY, token);
  },

  destroyToken: () => {
    localStorage.removeItem(TOKEN_KEY);
  },

  getAdminToken: () => localStorage.getItem(ADMIN_TOKEN_KEY),

  saveAdminToken: (token: string) => {
    localStorage.setItem(ADMIN_TOKEN_KEY, token);
  },

  destroyAdminToken: () => {
    localStorage.removeItem(ADMIN_TOKEN_KEY);
  },
};

export default jwtService;
