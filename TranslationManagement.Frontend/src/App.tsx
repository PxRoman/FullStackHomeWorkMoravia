import React, {useState} from 'react';
import {
  BrowserRouter as Router,
  Routes,
  Route,
  Link
} from "react-router-dom";

import TranslationList from "./components/translationManagement/TranslationList";
import TranslationEdit from "./components/translationManagement/TranslationEdit";

function App() {
  const [refreshData, setRefreshData] = useState<boolean>(false);

  return (
      <Router>
        <div className="App">
          <nav>
            <ul>
              <li>
                <Link to="/">Home</Link>
              </li>
              <li>
                <Link to="/translation-list">Translations</Link>
              </li>
            </ul>
          </nav>
          <Routes>
            <Route path="/" element={<Home />} />
            <Route path="/translation-list" element={<TranslationList refreshData={refreshData} setRefreshData={setRefreshData} />} />
            <Route path="/translation-list/:id" element={<TranslationEdit setRefreshData={setRefreshData} />} />
          </Routes>
        </div>
      </Router>
  );
}

function Home() {
  return <h2>Welcome to Translation Management Frontend</h2>;
}

export default App;
