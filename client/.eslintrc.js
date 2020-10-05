module.exports = {
  root: true,
  env: {
    node: true,
  },
  extends: ['plugin:vue/vue3-essential', '@vue/airbnb', '@vue/typescript/recommended'],
  parserOptions: {
    ecmaVersion: 2020,
  },
  rules: {
    'vue/no-setup-props-destructure': 'off',
    '@typescript-eslint/no-non-null-assertion': 'off',
    'object-curly-newline': 'off',
    'no-param-reassign': 'off',
    'max-len': 'off',
    indent: 'off',
    'no-console': process.env.NODE_ENV === 'production' ? 'warn' : 'off',
    'no-debugger': process.env.NODE_ENV === 'production' ? 'warn' : 'off',
  },
};