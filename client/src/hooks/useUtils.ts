const useUtils = () => {
  const evalURL = (pathOrDomain: string) => {
    if (pathOrDomain === '') return false;
    if (document.location.href.indexOf(pathOrDomain) !== -1) return true;
    return false;
  };

  return {
    evalURL,
  };
};

export default useUtils;
