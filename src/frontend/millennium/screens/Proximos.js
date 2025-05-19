import React, { useEffect, useState } from 'react';
import {
  View,
  Text,
  StyleSheet,
  ImageBackground,
  FlatList,
} from 'react-native';
import PageContainer from '../components/PageContainer.js';

export default function ProximosAgendamentos() {
  const [agendamentos, setAgendamentos] = useState([]);

  useEffect(() => {
    setAgendamentos([
      { id: 1, data: '22/05/2025', servico: 'Corte Degradê', barbeiro: 'Beatriz Ribeiro' },
      { id: 2, data: '25/05/2025', servico: 'Combo Especial', barbeiro: 'Ramon Wesley' },
      { id: 3, data: '30/05/2025', servico: 'Limpeza de Pele', barbeiro: 'Sávio Matos' },
    ]);
  }, []);

  return (
    <ImageBackground
      source={require('../assets/home-background.png')}
      style={styles.background}
    >
      <PageContainer>
        <Text style={styles.title}>Próximos Agendamentos</Text>

        {agendamentos.length === 0 ? (
          <Text style={styles.emptyText}>Nenhum agendamento futuro encontrado.</Text>
        ) : (
          <FlatList
            data={agendamentos}
            keyExtractor={(item) => item.id.toString()}
            renderItem={({ item, index }) => (
              <View style={styles.card}>
                <Text style={styles.numero}>{index + 1}.</Text>
                <View>
                  <Text style={styles.servico}>{item.servico}</Text>
                  <Text style={styles.barbeiro}>Barbeiro: {item.barbeiro}</Text>
                  <Text style={styles.data}>{item.data}</Text>
                </View>
              </View>
            )}
          />
        )}
      </PageContainer>
    </ImageBackground>
  );
}

const styles = StyleSheet.create({
  background: {
    flex: 1,
  },
  title: {
    color: '#fff',
    fontSize: 22,
    fontWeight: 'bold',
    textAlign: 'center',
    marginBottom: 140,
  },
  emptyText: {
    color: '#fff',
    textAlign: 'center',
    fontSize: 16,
  },
  card: {
    backgroundColor: 'rgba(54,54,54,0.9)',
    borderRadius: 15,
    padding: 15,
    marginBottom: 15,
    flexDirection: 'row',
    gap: 10,
    alignItems: 'center',
  },
  numero: {
    color: '#fff',
    fontWeight: 'bold',
    fontSize: 16,
  },
  servico: {
    color: '#fff',
    fontSize: 15,
    fontWeight: '600',
  },
  barbeiro: {
    color: '#ddd',
    fontSize: 13,
    marginBottom: 2,
  },
  data: {
    color: '#ccc',
    fontSize: 13,
  },
});